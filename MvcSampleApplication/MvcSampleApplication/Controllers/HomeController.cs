using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcSampleApplication.Models;

namespace MvcSampleApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //CookieOptions options = new CookieOptions()
            //{
            //    Expires = DateTime.Now.AddSeconds(4)
            //};
            //HttpContext.Response.Cookies.Append("address", "city,Hyd");

            HttpContext.Session.SetString("Name", "Ram");

            var Name = HttpContext.Session.GetString("Name");

            return View();
        }
        public IActionResult Get()
        {
            //    string address = string.Empty;
            //    HttpContext.Request.Cookies.TryGetValue("address", out address);
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
