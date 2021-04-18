using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VacationManager.Data.Data;
using VacationManager.Data.TimeOff;
using VacationManager.Web.Models.TimeOffViewModels;

namespace VacationManager.Web.Controllers
{
    public class SickTimeOffController : TimeOffController<SickTimeOff>
    {
        private readonly VacationDbContext _context;
        public SickTimeOffController(VacationDbContext context) : base(context, context.SickTimeOffs)
        {
            _context = context;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BaseTimeOffViewModel model)
        {


            if (ModelState.IsValid)
            {

                SickTimeOff timeOff = new SickTimeOff()
                {

                    From = model.From,
                    To = model.To,
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
        public ActionResult Approve(int id)
        {
            VacationDbContext context = new VacationDbContext();
            BaseTimeOff timeOff = context.SickTimeOffs.Find(id);
            timeOff.IsApproved = true;
            context.SaveChanges();
            context.Dispose();

            return RedirectToAction("../TimeOffs/Index");
        }
    }
}
