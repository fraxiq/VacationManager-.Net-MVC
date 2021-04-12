using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VacationManager.Data.Data;
using VacationManager.Data.TimeOff;

namespace VacationManager.Web.Controllers
{
    public abstract class TimeOffController<T> : Controller
where T : class
    {
        private readonly VacationDbContext _context;

        private DbSet<T> _items;
        public TimeOffController(VacationDbContext context, DbSet<T> items)
        {
            _context = context;
            _items = items;

        }

        public async Task<IActionResult> Index()
        {
            return View("../TimeOffs/Index", await _items.ToListAsync());
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            T timeOff = null;
            if (id != null)
            {
                timeOff = _items.Find(id);
            }

            _context.Dispose();

            return View(timeOff);
        }

        [HttpPost]
        public ActionResult Edit(T model)
        {
            _items.Update(model);
            _context.SaveChanges();
            _context.Dispose();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            T timeOff = _items.Find(id);
            _items.Remove(timeOff);
            _context.SaveChanges();
            _context.Dispose();

            return RedirectToAction("Index");
        }
    }
}
