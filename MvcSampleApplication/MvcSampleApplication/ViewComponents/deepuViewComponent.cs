using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcSampleApplication.Data;
using MvcSampleApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSampleApplication.Component
{
    public class deepuViewComponent:ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public deepuViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _context.EmployeeTable.ToListAsync();
            return View(data);
        }


    }
}
