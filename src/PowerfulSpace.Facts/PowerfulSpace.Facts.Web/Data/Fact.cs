using Calabonga.EntityFrameworkCore.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PowerfulSpace.Facts.Web.Data
{
    public class Fact : Auditable
    {
        public string Content { get; set; } = null!;

        public ICollection<Tag>? Tags { get; set; } = null!;
    }
}
