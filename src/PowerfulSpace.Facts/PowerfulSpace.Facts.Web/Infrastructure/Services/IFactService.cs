using Calabonga.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using PowerfulSpace.Facts.Web.Data;
using System.Collections.Generic;
using System.Linq;

namespace PowerfulSpace.Facts.Web.Infrastructure.Services
{


    public interface IFactService
    {
        IEnumerable<Fact> GetLast20();
    }




    public class FactService : IFactService
    {

        private readonly IUnitOfWork _unitOfWork;

        public FactService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;


        public IEnumerable<Fact> GetLast20()
        {
            var facts = _unitOfWork.GetRepository<Fact>()
                .GetAll(true)
                .Include(x => x.Tags)
                .OrderByDescending(x => x.CreatedAt)
                .Take(20)
                .AsEnumerable();

            return facts;
        }
    }
}
