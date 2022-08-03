using Calabonga.Microservices.BackgroundWorkers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PowerfulSpace.Facts.Web.Extensions;
using PowerfulSpace.Facts.Web.Infrastructure.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PowerfulSpace.Facts.Web.Infrastructure.HostedServices
{
    public class NotificationHostedService : ScheduledHostedServiceBase
    {
        //https://crontab.guru/
        protected override bool IsExecuteOnServerRestart => true;

        
#if !DEBUG
        protected override string Schedule => "*/1 * * * *";
#else
        protected override string Schedule => "*/15 * * * *";
#endif


        protected override string DisplayName => "Notification Scheduler";


        public NotificationHostedService(IServiceScopeFactory serviceScopeFactory, ILogger<NotificationHostedService> logger)
            :base(serviceScopeFactory, logger)
        {
            
        }


        protected override async Task ProcessInScopeAsync(IServiceProvider serviceProvider, CancellationToken token)
        {
            using var scope = serviceProvider.CreateScope();
            var notificationProvider = scope.ServiceProvider.GetService<INotificationProvider>();
            await notificationProvider!.ProcessAsync(token);
            Logger.NotificationProcessed(DateTime.Now.ToString("F"));
        }
    }
}
