using AutoMapper;
using Calabonga.AspNetCore.Controllers;
using Calabonga.AspNetCore.Controllers.Base;
using Calabonga.OperationResults;
using Calabonga.UnitOfWork;
using PowerfulSpace.Facts.Web.Data;
using PowerfulSpace.Facts.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PowerfulSpace.Facts.Web.Controllers.Facts.Queries
{
    public class FactGetByIdRequest : OperationResultRequestBase<FactViewModel>
    {

        public Guid Id { get; }

        public FactGetByIdRequest(Guid id)
        {
            Id = id;
        }

    }


    public class FactGetByIdRequestHandler : OperationResultRequestHandlerBase<FactGetByIdRequest, FactViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public FactGetByIdRequestHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }



        public override async Task<OperationResult<FactViewModel>> Handle(FactGetByIdRequest request, CancellationToken cancellationToken)
        {

            var operation = OperationResult.CreateResult<FactViewModel>();

            operation.AppendLog("Searching fact in DB");

            var entity = await _unitOfWork.GetRepository<Fact>()
                .GetFirstOrDefaultAsync(
                predicate:x => x.Id == request.Id,
                include: i => i.Include(x => x.Tags));

            if(entity is null)
            {
                operation.AddWarning($"Факт с идентификатором {request.Id} не найден");
                return operation;
            }

            operation.AppendLog("Fact found. Mapping...");
            var mapped = _mapper.Map<FactViewModel>(entity);
            operation.Result = mapped;
            operation.AppendLog("Return fact to UI");


            return operation;
        }


    }


}
