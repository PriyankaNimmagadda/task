using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcSampleApplication.DependencyInjection;

namespace MvcSampleApplication.Controllers
{
    public class DIController : Controller
    {
        private readonly InterfaceClass _AgeCalculater;
        public DIController(InterfaceClass AgeCalculator)
        {
            _AgeCalculater = AgeCalculator;
        }
        public IActionResult Index()
        {
            return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Index(IFormCollection form )
        //{
        //    var dob = DateTime.Parse(form["your Age"]);
        //    ViewBag DOB = dob;

        //    return View();
        //}
        
    }
}
