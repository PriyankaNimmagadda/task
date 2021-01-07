using Microsoft.AspNetCore.Mvc;
using MvcSampleApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSampleApplication.Controllers
{
    public class ViewBag:Controller
    {
        private readonly ApplicationDbContext _context;

        public ViewBag(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult ViewDataView()
        {
            var employee = _context.EmployeeTable.ToList();
            return View(employee);
            ViewData["Employee"] = employee;



            //ViewBag.Name = _context.EmployeeTable.ToList();
            //return View();

        }
        public IActionResult ViewBagView()
        {
            //var employee = _context.EmployeeTable.ToList();
            //return View(employee);
            // ViewData["Employee"] = employee;


            var employee= _context.EmployeeTable.ToList();
            ViewBag.Name = employee; 
            return View(employee);

        }
    }
}     
