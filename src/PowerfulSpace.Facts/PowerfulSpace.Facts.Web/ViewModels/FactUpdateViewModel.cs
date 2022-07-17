using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerfulSpace.Facts.Web.ViewModels
{
    public class FactUpdateViewModel
    {
        public Guid Id { get; set; }

        public string Content { get; set; }

        public IEnumerable<string> Tags { get; set; }
    }
}
