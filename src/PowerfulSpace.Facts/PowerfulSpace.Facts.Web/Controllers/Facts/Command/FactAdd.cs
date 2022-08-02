using AutoMapper;
using Calabonga.AspNetCore.Controllers;
using Calabonga.AspNetCore.Controllers.Records;
using Calabonga.OperationResults;
using Calabonga.UnitOfWork;
using MediatR;
using PowerfulSpace.Facts.Web.Data;
using PowerfulSpace.Facts.Web.Infrastructure.Services;
using PowerfulSpace.Facts.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PowerfulSpace.Facts.Web.Controllers.Facts.Command
{

    public record FactAddRequest(FactCreateViewModel Model) : OperationResultRequestBase<Unit>;



    public class FactAddRequestHandler : OperationResultRequestHandlerBase<FactAddRequest, Unit>
    {

        private readonly ITagService _tagService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public FactAddRequestHandler(ITagService tagService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _tagService = tagService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public override async Task<OperationResult<Unit>> Handle(
            FactAddRequest request,
            CancellationToken cancellationToken)
        {
            var operation = OperationResult.CreateResult<Unit>();

            var repository = _unitOfWork.GetRepository<Fact>();
            var fact = _mapper.Map<Fact>(request.Model);

            await _tagService.ProcessTagsAsync(request.Model, fact, cancellationToken);

            await repository.InsertAsync(fact, cancellationToken);

            await _unitOfWork.SaveChangesAsync();
            if (_unitOfWork.LastSaveChangesResult.IsOk)
            {
                operation.AddSuccess($"Fact {fact.Id} successfully created");
                operation.Result = Unit.Value;
                return operation;
            }

            operation.AddError(_unitOfWork.LastSaveChangesResult.Exception);
            return operation;

        }


    }

}
