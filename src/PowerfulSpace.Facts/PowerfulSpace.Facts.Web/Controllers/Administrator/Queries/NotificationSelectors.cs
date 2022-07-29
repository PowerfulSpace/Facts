using PowerfulSpace.Facts.Web.Data;
using PowerfulSpace.Facts.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PowerfulSpace.Facts.Web.Controllers.Administrator.Queries
{
    public static class NotificationSelectors
    {
        public static Expression<Func<Notification, NotificationViewModel>> Default => s => new NotificationViewModel
        {
            AddressFrom = s.AddressFrom,
            AddressTo = s.AddressTo,
            Content = s.Content,
            CreatedAt = s.CreatedAt,
            CreatedBy = s.CreatedBy,
            Id = s.Id,
            IsCompleted = s.IsCompleted,
            Title = s.Subject,
            UpdatedAt = s.UpdatedAt,
            UpdatedBy = s.UpdatedBy
        };
    }
}
