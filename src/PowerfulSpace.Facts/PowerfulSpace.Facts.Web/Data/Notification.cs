using Calabonga.EntityFrameworkCore.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerfulSpace.Facts.Web.Data
{
    public class Notification : Auditable
    {
        public string Subject { get; set; }

        public string Content { get; set; }

        public bool IsCompleted { get; set; }


        public string AddAdressFrom { get; set; }

        public string AddAdressTo { get; set; }
    }
}
