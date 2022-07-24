using PowerfulSpace.Facts.Web.Infrastructure.TagHelpers.PagedListTagHelper.Base;
using System.Collections.Generic;

namespace PowerfulSpace.Facts.Web.Infrastructure.TagHelpers.PagedListTagHelper
{
    public interface IPagerTagHelperService
    {
        PagerContext GetPagerContext(int pageIndex, int pageSize, int totalPages, int pagesInGroup);

        List<PagerPageBase> GetPages(PagerContext pagerContext);
    }


    public class PagerTagHelperService : IPagerTagHelperService
    {
        public PagerContext GetPagerContext(int pageIndex, int pageSize, int totalPages, int pagesInGroup)
        {
            throw new System.NotImplementedException();
        }

        public List<PagerPageBase> GetPages(PagerContext pagerContext)
        {
            throw new System.NotImplementedException();
        }
    }
}
