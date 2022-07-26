using MediatR;
using Microsoft.AspNetCore.Mvc;
using PowerfulSpace.Facts.Web.Controllers.Facts.Query;
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
            var operationResult = await _mediator.Send(new FactGetPagedRequest(pageIndex ?? 1, tag, search), HttpContext.RequestAborted);
            return View(operationResult);
        }


        public async Task<IActionResult> Show(Guid id)
        {          
            var fact = await _mediator.Send(new FactGetByIdRequest(id), HttpContext.RequestAborted);
            return View(fact);
        }
    }
}
