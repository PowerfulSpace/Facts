using AutoMapper;
using Calabonga.AspNetCore.Controllers;
using Calabonga.AspNetCore.Controllers.Records;
using Calabonga.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using PowerfulSpace.Facts.Web.Data;
using PowerfulSpace.Facts.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PowerfulSpace.Facts.Web.Controllers.Facts.Queries
{

    public record FactGetRandomRequest : RequestBase<FactViewModel>;


    public class FactGetRandomRequestHandler : RequestHandlerBase<FactGetRandomRequest, FactViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public FactGetRandomRequestHandler(IMapper mapper,IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        public override async Task<FactViewModel> Handle(FactGetRandomRequest request, CancellationToken cancellationToken)
        {
            var fact = await _unitOfWork.GetRepository<Fact>()
                .GetAll(true)
                .OrderBy(x => Guid.NewGuid())
                .FirstOrDefaultAsync(cancellationToken);

            if(fact == null)
            {
                return new FactViewModel { Content = "No data" };
            }

            var result = _mapper.Map<FactViewModel>(fact);
            return result;

        }
    }


}
