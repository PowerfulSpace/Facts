using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly List<SelectListItem> _subject;


        public SiteController(IMediator mediator)
        {
            _mediator = mediator;

            _subject = new List<string>
            {
                "Связь с разработчиком",
                "Жалоба",
                "Предложение",
                "Другое"
            }.Select(x => new SelectListItem{ Value = x, Text = x }).ToList();

        }




        public IActionResult About() => View();

        public IActionResult Random() => View();

        public IActionResult Cloud() => View();


        public IActionResult FeedBack()
        {
            ViewData["Subject"] = _subject;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FeedBack(FeedbackViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _mediator.Publish(new FeedbackNotification(model));
                    TempData["Feedback"] = "Feedback";
                    return RedirectToAction("FeedbackSent", "Site");
                }
                catch (Exception ex)
                {

                    return RedirectToAction("_Form", "Извините, не могу отправить сообщение:\n" + ex.Message);
                }
            }

            ViewData["Subject"] = _subject;
            return View(model);
        }


        public IActionResult Rss() => View();

        public IActionResult FeedbackSent()
        {
            if(TempData["Feedback"] is null)
            {
                return RedirectToAction("Index", "Facts");
            }
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
