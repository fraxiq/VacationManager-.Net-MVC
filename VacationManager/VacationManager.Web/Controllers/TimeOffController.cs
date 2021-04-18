using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using VacationManager.Data.Data;
using VacationManager.Data.TimeOff;
using VacationManager.Web.Models.TimeOffViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

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

        //Add Create Functionality

        public IActionResult Create()
        {
            return View("../TimeOffs/Create");
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

            return View("../TimeOffs/Index");
        }

        [HttpPost]
        public ActionResult Edit(T model)
        {
            _items.Update(model);
            _context.SaveChanges();
            _context.Dispose();

            return RedirectToAction("../TimeOffs/Index");
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.PaidTimeOffs
                .FirstOrDefaultAsync(m => m.id == id);
            if (team == null)
            {
                return NotFound();
            }

            return View("../TimeOffs/Delete");
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paidTimeOff = await _context.PaidTimeOffs.FindAsync(id);
            _context.PaidTimeOffs.Remove(paidTimeOff);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaidTimeOffExists(int id)
        {
            return _context.Teams.Any(e => e.ID == id);
        }


        
    }
}
