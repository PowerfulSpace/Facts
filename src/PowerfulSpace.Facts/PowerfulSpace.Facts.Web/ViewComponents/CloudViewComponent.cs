using Microsoft.AspNetCore.Mvc;
using PowerfulSpace.Facts.Web.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerfulSpace.Facts.Web.ViewComponents
{
    public class CloudViewComponent : ViewComponent
    {
        private readonly ITagService _tagService;

        public CloudViewComponent(ITagService tagService)
        {
            _tagService = tagService;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var tags = await _tagService.GetCloudAsync();
            return View(tags);
        }
    }
}
