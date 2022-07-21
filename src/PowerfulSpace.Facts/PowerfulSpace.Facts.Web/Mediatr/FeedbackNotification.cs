using Calabonga.UnitOfWork;
using Microsoft.Extensions.Logging;
using PowerfulSpace.Facts.Web.Mediatr.Base;
using System;

namespace PowerfulSpace.Facts.Web.Mediatr
{
    public class FeedbackNotification : NotificationBase
    {
        public FeedbackNotification(string content, Exception? exception = null)
            : base("FEEDBACK from powerfulFacts.ru", content, "powerful@space.com", "noreply@space.com", exception)
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
