using Calabonga.UnitOfWork;
using Microsoft.Extensions.Logging;
using PowerfulSpace.Facts.Web.Mediatr.Base;
using System;

namespace PowerfulSpace.Facts.Web.Mediatr
{
    public class FeedbackNotification : NotificationBase
    {
        public FeedbackNotification(string subject, string content, string addAdressTo, string addAdressFrom, Exception? exception = null)
            : base(subject, content, addAdressTo, addAdressFrom, exception)
        {
        }
    }

    public class FeedbackNotificationHandler : NotificationHandlerBase<FeedbackNotification>
    {
        public FeedbackNotificationHandler(IUnitOfWork unitOfWork, ILogger logger) 
            : base(unitOfWork, logger)
        {
        }
    }
}
