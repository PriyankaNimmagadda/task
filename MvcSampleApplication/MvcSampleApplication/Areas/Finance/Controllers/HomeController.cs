using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MvcSampleApplication.Areas.Finance.Controllers
{
    public class HomeController : Controller
    {
        [Area("Finance")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
