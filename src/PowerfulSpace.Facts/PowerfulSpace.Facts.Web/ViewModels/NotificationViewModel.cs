using Calabonga.EntityFrameworkCore.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerfulSpace.Facts.Web.ViewModels
{
    public class NotificationViewModel : Identity
    {
        public string Title { get; set; } = null!;

        public string? Content { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime? UpdatedAt { get; set; }

        public string? UpdatedBy { get; set; }

        public string AddressTo { get; set; } = null!;

        public string AddressFrom { get; set; } = null!;
    }
}
