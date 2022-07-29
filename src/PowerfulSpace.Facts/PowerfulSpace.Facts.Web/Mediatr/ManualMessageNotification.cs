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
        public ManualMessageNotification(string title, string content, string addAdressTo, string addAdressFrom)
            : base(title, content, addAdressTo, addAdressFrom, null)
        {
        }
    }


    public class ManualMessageNotificationHandler : NotificationHandlerBase<ManualMessageNotification>
    {
        public ManualMessageNotificationHandler(IUnitOfWork unitOfWork, ILogger<ManualMessageNotification> logger)
            :base(unitOfWork,logger)
        {

        }
    }

}
