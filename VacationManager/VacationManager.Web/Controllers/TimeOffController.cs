using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VacationManager.Data.Data;
using VacationManager.Data.TimeOff;
using VacationManager.Web.Models.TimeOffViewModels;

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BaseTimeOffViewModel model)
        {
            if (ModelState.IsValid)
            {

                PaidTimeOff timeOff = new PaidTimeOff()
                {
                    From = model.From,
                    To= model.To,
                    CreatedOn = DateTime.Now,
                    IsHalfDay = model.IsHalfDay,
                    IsApproved = model.IsApproved,
                    Requestor = model.Requestor
                };

                _context.Add(timeOff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        private static string SaveFile(IFormFile file)
        {
            var fileName = Path.GetFileName(file.FileName);
            var extension = fileName.Split('.').Last();
            var fileNameWithoutExtension = string.Join("", fileName.Split('.').Take(fileName.Length - 1));

            var newfileName = "wwwroot/images/" + string.Format("{0}-{1:ddMMYYYYHHmmss}.{2}",
                fileNameWithoutExtension,
                DateTime.Now,
                extension
            );

            if (!Directory.Exists(Path.GetDirectoryName(newfileName)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(newfileName));
            }

            using (var localFile = System.IO.File.OpenWrite(newfileName))
            {
                using (var uploadedFile = file.OpenReadStream())
                {
                    uploadedFile.CopyTo(localFile);
                }
            }

            return newfileName;
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

            return View("../TimeOffs/EditPaid");
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


        [HttpGet]
        public ActionResult Approve(int id)
        {
            VacationDbContext context = new VacationDbContext();
            BaseTimeOff timeOff = context.PaidTimeOffs.Find(id);
            timeOff.IsApproved = true;
            context.SaveChanges();
            context.Dispose();

            return RedirectToAction("../TimeOffs/Index");
        }
    }
}
