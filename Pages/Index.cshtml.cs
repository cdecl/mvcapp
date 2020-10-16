using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Net;

namespace mvcapp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        private static int _callcount = 0;

        public void OnGet()
        {
            ++_callcount;

            ViewData["Hostname"] = Dns.GetHostName();
            ViewData["CallCount"] = _callcount;
            ViewData["RemoteAddr"] = Request.HttpContext.Connection.RemoteIpAddress;
            ViewData["XForwardedFor"] = Request.Headers["X-Forwarded-For"].FirstOrDefault();
        }
    }
}

