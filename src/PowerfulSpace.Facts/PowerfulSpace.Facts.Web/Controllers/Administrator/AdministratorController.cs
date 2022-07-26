using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerfulSpace.Facts.Web.Controllers.Administrator
{
    public class AdministratorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
