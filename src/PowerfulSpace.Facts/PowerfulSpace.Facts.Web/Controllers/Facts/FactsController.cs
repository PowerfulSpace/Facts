using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PowerfulSpace.Facts.Web.Controllers.Facts.Queries;
using PowerfulSpace.Facts.Web.Infrastructure;
using PowerfulSpace.Facts.Web.Infrastructure.Services;
using PowerfulSpace.Facts.Web.ViewModels;
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

        [Authorize(Roles = AppData.AdministratorRoleName)]
        public async Task<IActionResult> Edit(Guid id, string returnUrl)
        {
            var operationResult = await _mediator.Send(new FactGetByIdForEditRequest(id, returnUrl));
            if (operationResult.Ok)
            {
                return View(operationResult.Result);
            }

            return RedirectToAction("Error", "Site", new { code = 404 });
        }

        [HttpPost]
        [Authorize(Roles = AppData.AdministratorRoleName)]
        public async Task<IActionResult> Edit(FactEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return Redirect(model.ReturnUrl);
        }


        public async Task<IActionResult> Rss()
        {
            var rss = await _mediator.Send(new FactGetRssRequest(), HttpContext.RequestAborted);
            return Content(rss);
        }

        public async Task<IActionResult> Random()
        {
            var fact = await _mediator.Send(new FactGetRandomRequest(), HttpContext.RequestAborted);
            return View(fact);
        }

        public IActionResult Cloud()
        {
            return View();
        }

        public async Task<IActionResult> Show(Guid id, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            var fact = await _mediator.Send(new FactGetByIdRequest(id), HttpContext.RequestAborted);
            return View(fact);
        }
    }
}
