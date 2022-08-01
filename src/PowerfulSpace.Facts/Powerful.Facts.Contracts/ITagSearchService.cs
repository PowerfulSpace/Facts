using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Powerful.Facts.Contracts
{
    public interface ITagSearchService
    {
        Task<List<string>> SearchTags(string tern);
    }
}
