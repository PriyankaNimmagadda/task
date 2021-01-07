using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using MvcSampleApplication.Data;
using MvcSampleApplication.Models;
using Newtonsoft.Json;
using X.PagedList;

namespace MvcSampleApplication.Controllers
{
    public class EmployeeTableModelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _memoryCache;
        private readonly IDistributedCache _distributedCache;

        public EmployeeTableModelsController(ApplicationDbContext context,IMemoryCache memoryCache,IDistributedCache distributedCache)
        {
            _context = context;
            _memoryCache = memoryCache;
            _distributedCache = distributedCache;
        }

        // GET: EmployeeTableModels
        public async Task<IActionResult> Index(int? Page)
        {
            int pagenumber = Page ?? 1;
            int pagesize = 3;
            var dept = _context.EmployeeTable.OrderBy(x => x.empId).ToPagedList(pagenumber, pagesize);
            return View(dept);
        }
//------------------------------------------RawQuery----------------------------------------------------------
        public IActionResult RawQuery()
        {
            var sql = "select * from EmployeeTable ";
            var data = _context.EmployeeTable.FromSqlRaw(sql).ToList();
            return View(data);
        }

        public IActionResult RawQueryComplex()
        {
            return View();
        }
//-------------------------------------Cache---------------------------------------------------------------
        public async Task<IActionResult> CacheIndex()
        {
            var cacheData = _memoryCache.Get("EmployeeTableModel");
            IList<EmployeeTableModel> data = new List<EmployeeTableModel>();
            if(cacheData==null)
            {
                data = await _context.EmployeeTable.ToListAsync();
                var CacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(60));
                _memoryCache.Set("EmployeeTableModel", data, CacheOptions);
            }
            else
            {
                data = (IList<EmployeeTableModel>)cacheData;
            }
            return View(data);
        }

        public IActionResult RemoveCache()
        {
            _memoryCache.Remove("EmployeeTable");
            return RedirectToAction("cacheIndex");
        }
//----------------------------------------RedisCache--------------------------------------------------------------
        public async Task<IActionResult> RedisCache()
        {
            IList<EmployeeTableModel> data = new List<EmployeeTableModel>();
            var isCachestring = _distributedCache.GetString("RedisData");
            if(string.IsNullOrEmpty(isCachestring))
            {
                data = await _context.EmployeeTable.ToListAsync();
                var datastring = JsonConvert.SerializeObject(data);
                var distributedCacheOptions = new DistributedCacheEntryOptions();
                distributedCacheOptions.SetSlidingExpiration(TimeSpan.FromSeconds(5000));
                await _distributedCache.SetStringAsync("RedisData", datastring, distributedCacheOptions);
            }
            else
            {
                data = JsonConvert.DeserializeObject<IList<EmployeeTableModel>>(isCachestring);
            }
            return View(data);
        }
        public IActionResult RemoveRedisCache()
        {
            _distributedCache.Remove("RedisData");
            return RedirectToAction("RedisCahche");
        }

//-------------------------------------------------------------------------------------------------------------------
        // GET: EmployeeTableModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeTableModel = await _context.EmployeeTable
                .FirstOrDefaultAsync(m => m.empId == id);
            if (employeeTableModel == null)
            {
                return NotFound();
            }

            return View(employeeTableModel);
        }

        // GET: EmployeeTableModels/Create
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Search()
        {
            return View(new List<EmployeeTableModel>());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Search(IFormCollection form)
        {
            var keyword = form["keyword"];
            var field = form["field"];
            IList<EmployeeTableModel> employee = new List<EmployeeTableModel>();
            switch (field)
            {
                case "empId":
                    var id = int.Parse(keyword);
                    employee = _context.EmployeeTable.Where(d => d.empId.Equals(id)).ToList();
                    break;
                case "empName":
                    employee = _context.EmployeeTable.Where(d => d.empName.StartsWith("keyword")).ToList();
                    break;
                case "empSalary":
                    var salary = decimal.Parse(keyword);
                    employee = _context.EmployeeTable.Where(d => d.empName.Equals(salary)).ToList();
                    break;
                case "empDob":
                    var dob = DateTime.Parse(keyword);
                    employee = _context.EmployeeTable.Where(d => d.empName.Equals(dob)).ToList();
                    break;
            }
            return View(employee);
        }


        // POST: EmployeeTableModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("empId,empName,empSalary,empDob")] EmployeeTableModel employeeTableModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeTableModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeTableModel);
        }

        // GET: EmployeeTableModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeTableModel = await _context.EmployeeTable.FindAsync(id);
            if (employeeTableModel == null)
            {
                return NotFound();
            }
            return View(employeeTableModel);
        }

        // POST: EmployeeTableModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("empId,empName,empSalary,empDob")] EmployeeTableModel employeeTableModel)
        {
            if (id != employeeTableModel.empId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeTableModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeTableModelExists(employeeTableModel.empId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employeeTableModel);
        }

        // GET: EmployeeTableModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeTableModel = await _context.EmployeeTable
                .FirstOrDefaultAsync(m => m.empId == id);
            if (employeeTableModel == null)
            {
                return NotFound();
            }

            return View(employeeTableModel);
        }

        // POST: EmployeeTableModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeTableModel = await _context.EmployeeTable.FindAsync(id);
            _context.EmployeeTable.Remove(employeeTableModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeTableModelExists(int id)
        {
            return _context.EmployeeTable.Any(e => e.empId == id);
        }
       
    }

}
