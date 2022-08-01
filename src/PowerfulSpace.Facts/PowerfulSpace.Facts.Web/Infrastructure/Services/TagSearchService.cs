using Calabonga.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Powerful.Facts.Contracts;
using PowerfulSpace.Facts.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerfulSpace.Facts.Web.Infrastructure.Services
{
    public class TagSearchService : ITagSearchService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TagSearchService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<string>> SearchTags(string tern)
        {
            var items =  await _unitOfWork.GetRepository<Tag>()
                .GetAll(
                    s => s.Name,
                    x => x.Name.ToLower().StartsWith(tern.ToLower()),
                    true)
                .ToListAsync();

            return items;
        }
    }
}
