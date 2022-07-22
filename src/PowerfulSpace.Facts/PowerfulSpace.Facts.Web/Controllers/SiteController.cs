using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PowerfulSpace.Facts.Web.Mediatr;
using PowerfulSpace.Facts.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PowerfulSpace.Facts.Web.Controllers
{
    public class SiteController : Controller
    {

        private readonly IMediator _mediator;


        public SiteController(IMediator mediator)
        {
            _mediator = mediator;
        }


        public IActionResult Index(int? pageIndex, string tag, string search)
        {

            ViewData["Index"] = pageIndex;
            ViewData["Tag"] = tag;
            ViewData["Search"] = search;

            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            await _mediator.Publish(new ErrorNotification("Privicy test for notification"), HttpContext.RequestAborted);
            await _mediator.Publish(new FeedbackNotification("Hello your site os working good.Thanks"), HttpContext.RequestAborted);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
