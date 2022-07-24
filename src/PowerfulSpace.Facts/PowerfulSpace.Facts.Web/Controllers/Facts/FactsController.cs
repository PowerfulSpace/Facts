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

            var operationResult = await _mediator.Send(new FactGetPagedRequest(pageIndex ?? 0, tag, search), HttpContext.RequestAborted);

            return View(operationResult);
        }
    }
}
