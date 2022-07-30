using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using Powerful.Facts.RazorLibrary;
using PowerfulSpace.Facts.Web.Mediatr;
using PowerfulSpace.Facts.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PowerfulSpace.Facts.Web.Controllers
{
    public class SiteController : Controller
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly IWebHostEnvironment _environment;
        private readonly IMediator _mediator;
        private readonly List<SelectListItem> _subject;


        public SiteController(IJSRuntime jsRuntime,IMediator mediator, IWebHostEnvironment environment)
        {
            _jsRuntime = jsRuntime;
            _environment = environment;
            _mediator = mediator;

            _subject = new List<string>
            {
                "Связь с разработчиком",
                "Жалоба",
                "Предложение",
                "Другое"
            }.Select(x => new SelectListItem{ Value = x, Text = x }).ToList();

        }




        public async Task<IActionResult> About()
        {
            var interop = new RazorInterop(_jsRuntime);
            await interop.ShowToast("test", "tetle");
            return View();
        }

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
                    if(TempData["Capture"] is null)
                    {
                        ModelState.AddModelError("_Form", "Извините, не могу отправить сообщение, не работает reCapture");
                        ViewData["Subject"] = _subject;
                        return View(model);
                    }

                    var result = int.Parse(TempData["Capture"].ToString()!);

                    if (model.HumanNumber != result)
                    {
                        ModelState.AddModelError("_Form", "Извините, не могу отправить сообщение, результат вычисления не верный");
                        ViewData["Subject"] = _subject;
                        return View(model);
                    }

                    await _mediator.Publish(new FeedbackNotification(model));
                    TempData["Feedback"] = "Feedback";
                    return RedirectToAction("FeedbackSent", "Site");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("_Form", "Извините, не могу отправить сообщение:\n" + ex.Message);
                }
            }

            ViewData["Subject"] = _subject;
            return View(model);
        }


        

        public IActionResult FeedbackSent()
        {
            if(TempData["Feedback"] is null)
            {
                return RedirectToAction("Index", "Facts");
            }
            return View();
        }



        public IActionResult GetImage(int? x, int? y, int? z)
        {
            Random r = new();
            x ??= r.Next(21, 30);
            y ??= r.Next(11, 20);
            z ??= r.Next(1, 30);

            var width = 100;
            var height = 30;
            using Bitmap bmp = new Bitmap(width, height);
            using var g = Graphics.FromImage(bmp);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            var stringFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

            var backgroundColors = new[] { Color.BlueViolet, Color.Blue, Color.Brown, Color.DarkMagenta, Color.DarkGreen };
            var foregroundColors = new[] { Color.AliceBlue, Color.Gold, Color.GhostWhite, Color.Aqua, Color.Ivory };

            g.Clear(backgroundColors[r.Next(0, backgroundColors.Length - 1)]);

            var font = new Font("Arial", 14, FontStyle.Bold);
            var brush = new SolidBrush(foregroundColors[r.Next(0, foregroundColors.Length - 1)]);

            g.DrawString($"{x}+{y}-{z}", font, brush, new PointF(50, 15), stringFormat);

            var filename = string.Concat(_environment.WebRootPath, "/", Guid.NewGuid().ToString("N"));

            bmp.Save(filename, ImageFormat.MemoryBmp);

            byte[] bytes;
            using (FileStream stream = new FileStream(filename, FileMode.Open))
            {
                bytes = new byte[stream.Length];
                stream.Read(bytes, 0, bytes.Length);
            }

            System.IO.File.Delete(filename);
            TempData["Capture"] = x + y - z;

            return new FileContentResult(bytes, "image/jpeg");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
