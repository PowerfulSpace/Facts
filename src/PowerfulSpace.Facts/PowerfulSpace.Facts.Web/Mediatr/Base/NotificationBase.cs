using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerfulSpace.Facts.Web.Mediatr.Base
{
    public abstract class NotificationBase : INotification
    {

        public string Subject { get; }
        public string Content { get; }
        public string AddAdressFrom { get; }
        public string AddAdressTo { get; }
        public Exception? Exception { get; }

        protected NotificationBase(string subject, string content, string addAdressTo, string addAdressFrom, Exception? exception = null)
        {
            Subject = subject;
            Content = content;
            AddAdressFrom = addAdressFrom;
            AddAdressTo = addAdressTo;
            Exception = exception;
        }

    }
}
