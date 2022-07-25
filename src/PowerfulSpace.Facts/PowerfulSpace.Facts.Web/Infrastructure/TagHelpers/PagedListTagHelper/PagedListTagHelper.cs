using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerfulSpace.Facts.Web.Infrastructure.TagHelpers.PagedListTagHelper
{
    [HtmlTargetElement("pager", Attributes = PagerListPageIndexAttributeName)]
    [HtmlTargetElement("pager", Attributes = PagerListPageSizeAttributeName)]
    [HtmlTargetElement("pager", Attributes = PagerListPageTotalCountAttributeName)]
    public class PagedListTagHelper : TagHelper
    {

        private readonly IPagerTagHelperService _tagHelperService;
        protected  IHtmlGenerator _htmlGenerator { get; set; }


        private const string PagerListPageIndexAttributeName = "asp-paged-list-page-index";
        private const string PagerListPageSizeAttributeName = "asp-paged-list-page-size";
        private const string PagerListPageTotalCountAttributeName = "asp-paged-list-total-count";



        [HtmlAttributeName(PagerListPageIndexAttributeName)]
        public int PagedListIndex { get; set; }

        [HtmlAttributeName(PagerListPageSizeAttributeName)]
        public int PagedListSize { get; set; }

        [HtmlAttributeName(PagerListPageTotalCountAttributeName)]
        public int PagedListTotalCount { get; set; }



        private string DisableCss => "disabled";
        private string PageLinkCss => "page-link";
        private string RootTagCss => "pagination";
        private string ActiveTagCss => "active";
        private string PageItemCss => "page-item";
        private byte VisibleGroupCount => 10;



        public PagedListTagHelper(IPagerTagHelperService tagHelperService, IHtmlGenerator htmlGenerator)
        {
            _tagHelperService = tagHelperService;
           _htmlGenerator = htmlGenerator;
        }




        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            if(PagedListTotalCount <= 1) { return; }

            var ul = new TagBuilder("ul");
            ul.AddCssClass(RootTagCss);

            var pagerContext = _tagHelperService.GetPagerContext(PagedListIndex, PagedListSize, PagedListTotalCount, VisibleGroupCount);
            var pages = _tagHelperService.GetPages(pagerContext);

            foreach (var page in pages)
            {
                var li = new TagBuilder("li");
                li.AddCssClass(PageItemCss);
                var a = new TagBuilder("a");
                a.AddCssClass(PageLinkCss);

                if (page.IsActive) { a.AddCssClass(ActiveTagCss); }
                if (page.IsDisabled) { a.AddCssClass(DisableCss); }

                a.InnerHtml.AppendHtml(GenerateLink(page.Title, page.Value.ToString()));
                ul.InnerHtml.AppendHtml(a);
            }

            output.Content.AppendHtml(ul);
            base.Process(context, output);
        }


        private string GenerateLink(string linkText, string routeValue)
        {
            return linkText;
        }

    }
}
