using Calabonga.EntityFrameworkCore.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerfulSpace.Facts.Web.Data
{
    public class Tag : Identity
    {
        public string Name { get; set; } = null!;

        public ICollection<Fact> Facts { get; set; } = null!;
    }
}
