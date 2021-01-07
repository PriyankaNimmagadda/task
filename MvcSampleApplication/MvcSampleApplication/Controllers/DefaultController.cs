using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MvcSampleApplication.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult ComponentTest()
        {
            return View();
        }
    }
}
