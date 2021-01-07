using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NewCore3xMVC.Areas.Finance.Controllers
{
    public class DefaultController : Controller
    {
        [Area("Finance")]
        public IActionResult Index()
        {
            return View();
        }
    }
}