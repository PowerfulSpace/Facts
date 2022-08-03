using Calabonga.UnitOfWork;
using PowerfulSpace.Facts.Web.Data;
using PowerfulSpace.Facts.Web.Infrastructure.Mappers.Base;
using PowerfulSpace.Facts.Web.Infrastructure.Providers;
using PowerfulSpace.Facts.Web.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace PowerfulSpace.Facts.Web.Infrastructure.Mappers
{
    public class NotificationMapperConfiguration : MapperConfigurationBase
    {
        public NotificationMapperConfiguration()
        {
            CreateMap<Notification, EmailMessage>()
                .ForMember(x => x.Author, o => o.MapFrom(x => x.CreatedBy))
                .ForMember(x => x.Recipient, o => o.Ignore())
                .ForMember(x => x.Body, o => o.MapFrom(x => x.Content))
                .ForMember(x => x.IsHtml, o => o.MapFrom(_ => true));
        }

    }
}
