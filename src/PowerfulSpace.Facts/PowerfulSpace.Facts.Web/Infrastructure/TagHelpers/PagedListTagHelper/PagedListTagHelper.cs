using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerfulSpace.Facts.Web.Infrastructure.TagHelpers.PagedListTagHelper
{
    [HtmlTargetElement("pager", Attributes = TextAttributeName)]
    public class PagedListTagHelper : TagHelper
    {
        private const string TextAttributeName = "asp-text";
        private readonly IPagerTagHelperService _tagHelperService;

        [HtmlAttributeName(TextAttributeName)]
        public string Text { get; set; }


        public PagedListTagHelper(IPagerTagHelperService tagHelperService)
        {
            _tagHelperService = tagHelperService;
        }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            var pagerContext = _tagHelperService.GetPagerContext();

            var pages = _tagHelperService.GetPages(pagerContext);

            output.Content.Append(Text);
            base.Process(context, output);
        }
    }
}
