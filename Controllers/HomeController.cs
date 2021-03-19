using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvcapp.Models;
using System.Net;

namespace mvcapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private static int _callcount = 0;

        // [Route("/")]
        [Route("/{sleep?}")]
        public IActionResult Index(int sleep)
        {
            if (sleep > 0) {
                Task.Delay(sleep).Wait();
            }
            ++_callcount;

            ViewData["Hostname"] = Dns.GetHostName();
            ViewData["CallCount"] = _callcount;
            ViewData["Sleep"] = sleep;
            ViewData["RemoteAddr"] = Request.HttpContext.Connection.RemoteIpAddress;
            ViewData["XForwardedFor"] = Request.Headers["X-Forwarded-For"].FirstOrDefault();
            ViewData["UserAgent"] = Request.Headers["User-Agent"].ToString();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
