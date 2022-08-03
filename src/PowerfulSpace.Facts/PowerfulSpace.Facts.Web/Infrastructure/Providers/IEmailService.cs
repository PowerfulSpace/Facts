using System.Threading;
using System.Threading.Tasks;

namespace PowerfulSpace.Facts.Web.Infrastructure.Providers
{
    public interface IEmailService
    {
        Task<bool> SendAsync(EmailMessage message, CancellationToken cancellationToken);
    }


    public class EmailService : IEmailService
    {
        public async Task<bool> SendAsync(EmailMessage message, CancellationToken cancellationToken)
        {
            await Task.Delay(2300, cancellationToken);
            return true;
        }
    }
}
