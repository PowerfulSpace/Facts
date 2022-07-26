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

        public IActionResult About() => View();

        public IActionResult Random() => View();

        public IActionResult Cloud() => View();

        public IActionResult FeedBack() => View();

        public IActionResult Rss() => View();



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
