using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VacationManager.Data.Data;
using VacationManager.Data.TimeOff;
using VacationManager.Web.Models.TimeOffViewModels;

namespace VacationManager.Web.Controllers
{
    public class UnpaidTimeOffController : TimeOffController<UnpaidTimeOff>
    {
        private readonly VacationDbContext _context;

        public UnpaidTimeOffController(VacationDbContext context) : base(context, context.UnpaidTimeOffs)
        {
            _context = context;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BaseTimeOffViewModel model)
        {


            if (ModelState.IsValid)
            {

                UnpaidTimeOff timeOff = new UnpaidTimeOff()
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
        [HttpGet]
        public ActionResult Approve(int id)
        {
            VacationDbContext context = new VacationDbContext();
            BaseTimeOff timeOff = context.UnpaidTimeOffs.Find(id);
            timeOff.IsApproved = true;
            context.SaveChanges();
            context.Dispose();

            return RedirectToAction("../TimeOffs/Index");
        }
    }
}
