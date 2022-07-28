using Calabonga.UnitOfWork;
using Microsoft.Extensions.Logging;
using PowerfulSpace.Facts.Web.Mediatr.Base;
using PowerfulSpace.Facts.Web.ViewModels;
using System;

namespace PowerfulSpace.Facts.Web.Mediatr
{
    public class FeedbackNotification : NotificationBase
    {
        public FeedbackNotification(FeedbackViewModel model)
            : base("FEEDBACK from powerfulFacts.by", model.ToString()!, "powerful@space.com", "noreply@space.com")
        {
        }
    }

    public class FeedbackNotificationHandler : NotificationHandlerBase<FeedbackNotification>
    {
        public FeedbackNotificationHandler(IUnitOfWork unitOfWork, ILogger<FeedbackNotification> logger) 
            : base(unitOfWork, logger)
        {
        }
    }
}
