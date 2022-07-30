using MediatR;
using Microsoft.AspNetCore.Mvc;
using PowerfulSpace.Facts.Web.Controllers.Facts.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerfulSpace.Facts.Web.Controllers.Facts
{
    public class FactsController : Controller
    {

        private readonly IMediator _mediator;

        public FactsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(int? pageIndex, string tag, string search)
        {
            ViewData["search"] = search;
            ViewData["tag"] = tag;

            var index = pageIndex ?? 1;

            var operationResult = await _mediator.Send(new FactGetPagedRequest(index, tag, search), HttpContext.RequestAborted);
           
            if(operationResult.Ok && operationResult.Result.TotalPages > index)
            {
                return RedirectToAction(nameof(Index), new { tag, search, pageIndex = 1 });
            }

            return View(operationResult);

        }

        public IActionResult Rss() => View();

        public async Task<IActionResult> Random()
        {
            var fact = await _mediator.Send(new FactGetRandomRequest(), HttpContext.RequestAborted);
            return View(fact);
        }


        public async Task<IActionResult> Show(Guid id, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            var fact = await _mediator.Send(new FactGetByIdRequest(id), HttpContext.RequestAborted);
            return View(fact);
        }
    }
}
