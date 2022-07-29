﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PowerfulSpace.Facts.Web.Controllers.Administrator.Queries;
using PowerfulSpace.Facts.Web.Mediatr;
using PowerfulSpace.Facts.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerfulSpace.Facts.Web.Controllers.Administrator
{
    [Authorize]
    public class AdministratorController : Controller
    {

        private readonly IMediator _mediator;

        public AdministratorController(IMediator mediator) => _mediator = mediator;
        


        public IActionResult Index() => View();

        public IActionResult Add() => View();


        public IActionResult SendNotification(string subject, string mailTo, string addessFrom = "powrf@full.net")
        {
            var model = new ManualNotificationViewModel { MailTo = mailTo,Subject = subject, MailFrom = addessFrom};
            return View(model);
        }


        [HttpPost]
        [ActionName(nameof(SendNotification))]
        public async Task<IActionResult> SendNotificationConfirm(ManualNotificationViewModel  model)
        {
            await _mediator.Publish(new ManualMessageNotification(model.Subject!, model.Body!, model.MailFrom!, model.MailTo!), HttpContext.RequestAborted);
            return RedirectToAction(nameof(Notifications));
        }


        public async Task<IActionResult> Notifications(int? id, string search, bool notPrecessedOnly = false)
        {
            ViewData["NotProcessedOnly"] = notPrecessedOnly;
            var data = await _mediator.Send(new NotificationGetPagedRequest(id ?? 1, search, notPrecessedOnly), HttpContext.RequestAborted);
            return View(data);
        }


        public async Task<IActionResult> NotificationById(Guid id)
        {
            var data = await _mediator.Send(new NotificationGetByIdRequest(id), HttpContext.RequestAborted);
            return View(data);
        }

    }
}
