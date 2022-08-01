using Calabonga.UnitOfWork;
using Powerful.Facts.Contracts;
using PowerfulSpace.Facts.Web.Data;
using System.Collections.Generic;
using System.Linq;

namespace PowerfulSpace.Facts.Web.Infrastructure.Services
{
    public class TagSearchService : ITagSearchService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TagSearchService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<string> SearchTags(string tern)
        {
            var items = _unitOfWork.GetRepository<Tag>()
                .GetAll(
                    s => s.Name,
                    x => x.Name.ToLower().StartsWith(tern.ToLower()),
                    true)
                .ToList();

            return items;
        }
    }
}
