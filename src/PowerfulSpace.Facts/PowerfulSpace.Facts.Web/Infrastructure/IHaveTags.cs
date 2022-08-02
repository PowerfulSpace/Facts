using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerfulSpace.Facts.Web.Infrastructure
{
    public interface IHaveTags
    {
        List<string>? Tags { get; set; }
    }
}
