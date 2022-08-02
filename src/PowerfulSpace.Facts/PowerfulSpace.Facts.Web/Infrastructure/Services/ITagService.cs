using Calabonga.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using PowerfulSpace.Facts.Web.Data;
using PowerfulSpace.Facts.Web.Infrastructure.Helpers;
using PowerfulSpace.Facts.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PowerfulSpace.Facts.Web.Infrastructure.Services
{

    public interface ITagService
    {
        Task<List<TagCloud>> GetCloudAsync();

        Task ProcessTagsAsync(IHaveTags viewModel, Fact fact, CancellationToken cancellationToken);
    }



    public class TagService : ITagService
    {

        private readonly IUnitOfWork _unitOfWork;

        public TagService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public async Task<List<TagCloud>> GetCloudAsync()
        {
            var tags = await _unitOfWork.GetRepository<Tag>()
                .GetAll(true)
                .Select(s => new TagCloud
                {
                    Id = s.Id,
                    Name = s.Name,
                    CssClass = "",
                    Total = s.Facts == null ? 0 : s.Facts!.Count
                })
                .ToListAsync();

            var cloud = TagCloudHelper.Generate(tags, 10);

            return cloud;
        }



        public async Task ProcessTagsAsync(IHaveTags viewModel, Fact fact, CancellationToken cancellationToken)
        {
            if (viewModel?.Tags is null)
            {
                throw new ArgumentNullException(nameof(viewModel));
            }

            if (fact == null)
            {
                throw new ArgumentNullException(nameof(fact));
            }

            fact.Tags ??= new Collection<Tag>();

            var tagRepository = _unitOfWork.GetRepository<Tag>();

            var afterEdit = viewModel.Tags!.ToArray();
            var oldArray = tagRepository
                           .GetAll(
                               x => x.Name.ToLower(),
                               x => x.Facts!.Select(p => p.Id).Contains(fact.Id),
                               null)
                           .ToArray();

            var (toCreate, toDelete) = new FactHelper().FindDifference(oldArray, afterEdit);

            if (toDelete.Any())
            {
                foreach (var name in toDelete)
                {
                    var tag = await tagRepository.GetFirstOrDefaultAsync(predicate: x => x.Name.ToLower() == name, disableTracking: false);
                    if (tag == null)
                    {
                        continue;
                    }

                    fact.Tags!.Remove(tag);

                    var used = _unitOfWork.GetRepository<Fact>()
                                          .GetAll(x => x.Tags!.Select(t => t.Name).Contains(tag.Name), true)
                                          .ToArray();

                    if (used.Length == 1)
                    {
                        tagRepository.Delete(tag);
                    }
                }
            }



            foreach (var name in toCreate)
            {
                var tag = await tagRepository.GetFirstOrDefaultAsync(predicate: x => x.Name.ToLower() == name, disableTracking: false);
                if (tag == null)
                {
                    var t = new Tag
                    {
                        Name = name.Trim().ToLower()
                    };
                    await tagRepository.InsertAsync(t, cancellationToken);
                    fact.Tags!.Add(t);
                }
                else
                {
                    fact.Tags!.Add(tag);
                }
            }
        }








        public class TagCloudHelper
        {
            public static List<TagCloud> Generate(List<TagCloud> items, int clusterCount)
            {
                var totalCount = items.Count;
                var tagsCloud = items.OrderBy(x => x.Total).ToList();

                var clusters = new List<List<TagCloud>>();
                if (totalCount > 0)
                {
                    var min = tagsCloud.Min(c => c.Total);
                    var max = tagsCloud.Max(c => c.Total) + min;
                    var completeRange = max - min;
                    var groupRange = completeRange / (double)clusterCount;
                    var cluster = new List<TagCloud>();
                    var currentRange = min + groupRange;
                    for (int i = 0; i < totalCount; i++)
                    {
                        while (tagsCloud.ToArray()[i].Total > currentRange)
                        {
                            clusters.Add(cluster);
                            cluster = new List<TagCloud>();
                            currentRange += groupRange;
                        }
                        cluster.Add(tagsCloud.ToArray()[i]);
                    }
                    clusters.Add(cluster);
                }
                var result = new List<TagCloud>();
                for (int i = 0; i < clusters.Count; i++)
                {
                    result.AddRange(clusters[i].Select(item => new TagCloud
                    {
                        Id = item.Id,
                        Name = item.Name,
                        CssClass = "tag" + i,
                        Total = item.Total
                    }));
                }

                return result.OrderBy(x => x.Name).ToList();

            }
        }
    }
}
