using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace NewCore3xMVC.Controllers
{
    public class SessionDemoController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.SetString("Name", "Ram");

            var name = HttpContext.Session.GetString("Name");

            HttpContext.Response.Cookies.Append("name", "Shyam");

            CookieOptions options = new CookieOptions()
            {
                Expires = DateTime.Now.AddSeconds(4)
            };

            HttpContext.Response.Cookies.Append("Address", "Hitech City, Hyderabad", options);

            return View();
        }

        public IActionResult Get()
        {
            string address = string.Empty;
            HttpContext.Request.Cookies.TryGetValue("Address", out address);
            return View();
        }
    }

}