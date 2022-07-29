using Calabonga.UnitOfWork;
using Microsoft.Extensions.Logging;
using PowerfulSpace.Facts.Web.Mediatr.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerfulSpace.Facts.Web.Mediatr
{
    public class ManualMessageNotification : NotificationBase
    {
        public ManualMessageNotification(string title, string content, string addressFrom, string addressTo)
            : base(title, content, addressFrom, addressTo, null)
        {
        }
    }

    public class ManualMessageNotificationHandler : NotificationHandlerBase<ManualMessageNotification>
    {
        public ManualMessageNotificationHandler(IUnitOfWork unitOfWork, ILogger<ManualMessageNotification> logger)
            : base(unitOfWork, logger)
        {
        }
    }

}
