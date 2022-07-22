using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerfulSpace.Facts.Web.ViewModels
{
    public class FactCreateViewModel
    {
        public string Content { get; set; } = null!;

        public IEnumerable<string> Tags { get; set; } = null!;
    }
}
