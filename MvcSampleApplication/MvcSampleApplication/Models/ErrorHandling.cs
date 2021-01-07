using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MvcSampleApplication.Models
{
    public class ErrorHandling : Controller
    {
        private readonly ILogger<ErrorHandling> _logger;

        public ErrorHandling(ILogger<ErrorHandling> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            try
            {
                var z = 0;
                return Content((1 / z).ToString());
            }
            catch(Exception )
            {
                throw;
            }
            return View();
        }
    }
}
