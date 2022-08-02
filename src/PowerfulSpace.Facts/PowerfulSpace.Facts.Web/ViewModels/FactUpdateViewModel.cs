using PowerfulSpace.Facts.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerfulSpace.Facts.Web.ViewModels
{
    public class FactUpdateViewModel : IHaveTags
    {
        public Guid Id { get; set; }

        public string Content { get; set; } = null!;

        public List<string>? Tags { get; set; } = null!;

    }
}
