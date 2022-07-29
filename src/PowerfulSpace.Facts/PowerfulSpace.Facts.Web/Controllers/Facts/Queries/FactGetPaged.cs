using AutoMapper;
using Calabonga.AspNetCore.Controllers;
using Calabonga.AspNetCore.Controllers.Base;
using Calabonga.OperationResults;
using Calabonga.UnitOfWork;
using PowerfulSpace.Facts.Web.Data;
using PowerfulSpace.Facts.Web.ViewModels;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Calabonga.PredicatesBuilder;
using System.Linq.Expressions;

namespace PowerfulSpace.Facts.Web.Controllers.Facts.Queries
{
    public class FactGetPagedRequest : OperationResultRequestBase<IPagedList<FactViewModel>>
    {
        public int PageIndex { get; set; }
        public string? Tag { get; set; }
        public string? Search { get; set; }
        public int PageSize { get; set; } = 20;


        public FactGetPagedRequest(int pageIndex, string? tag, string? search)
        {
            PageIndex = pageIndex - 1 < 0 ? 0 : pageIndex - 1;
            Tag = tag;
            Search = search;
        }
    }


    public class FactGetPagedRequestHandler : OperationResultRequestHandlerBase<FactGetPagedRequest, IPagedList<FactViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public FactGetPagedRequestHandler(IMapper mapper,IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public override async Task<OperationResult<IPagedList<FactViewModel>>> Handle(FactGetPagedRequest request, CancellationToken cancellationToken)
        {
            var operation = OperationResult.CreateResult<IPagedList<FactViewModel>>();

            var predicate = BuildPredicate(request);


            var items = await _unitOfWork.GetRepository<Fact>()
                .GetPagedListAsync(
                predicate: predicate,
                include: i => i.Include(x => x.Tags),
                orderBy: o => o.OrderByDescending(x => x.CreatedAt),
                pageIndex: request.PageIndex,
                pageSize: request.PageSize,
                cancellationToken: cancellationToken);

            var mapped = _mapper.Map<IPagedList<FactViewModel>>(items);
            operation.Result = mapped;
            operation.AddSuccess("Success");

            return operation;
        }



        private Expression<Func<Fact,bool>> BuildPredicate(FactGetPagedRequest request)
        {
            var predicate = PredicateBuilder.True<Fact>();


            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                predicate = predicate.And(x => x.Content.Contains(request.Search));
            }

            if (!string.IsNullOrWhiteSpace(request.Tag))
            {
                predicate = predicate.And(x => x.Tags.Select(t => t.Name).Contains(request.Tag));
            }

            return predicate;
        }
    }
}
