using Calabonga.UnitOfWork;
using MediatR;
using Microsoft.Extensions.Logging;
using PowerfulSpace.Facts.Web.Mediatr.Base;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PowerfulSpace.Facts.Web.Mediatr
{
    public class ErrorNotification : NotificationBase
    {
        public ErrorNotification(string subject, string content, string addAdressTo, string addAdressFrom, Exception? exception = null) 
            : base(subject, content, addAdressTo, addAdressFrom, exception)
        {
        }
    }

    public class ErrorNotificationHandler : NotificationHandlerBase<ErrorNotification>
    {
        public ErrorNotificationHandler(IUnitOfWork unitOfWork, ILogger<ErrorNotification> logger)
            : base(unitOfWork, logger)
        {

        }
    }
}
