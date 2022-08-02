using Calabonga.UnitOfWork;
using PowerfulSpace.Facts.Web.Data;
using PowerfulSpace.Facts.Web.Infrastructure.Mappers.Base;
using PowerfulSpace.Facts.Web.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace PowerfulSpace.Facts.Web.Infrastructure.Mappers
{
    public class TagMapperConfiguration : MapperConfigurationBase
    {
        public TagMapperConfiguration()
        {
            CreateMap<Tag,TagViewModel>();
            CreateMap<Tag, TagUpdateViewModel>();

            CreateMap<TagUpdateViewModel, Tag>()
                .ForMember(x => x.Facts, o => o.Ignore());
        }

    }
}
