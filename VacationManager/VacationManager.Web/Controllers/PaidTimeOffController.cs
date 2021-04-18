using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VacationManager.Data.Data;
using VacationManager.Data.TimeOff;
using VacationManager.Web.Models.TimeOffViewModels;
using VacationManager.Web.Models.TimeOffViewModels.PaidTimeOffs;

namespace VacationManager.Web.Controllers
{
    public class PaidTimeOffController : TimeOffController<PaidTimeOff>
    {
        private readonly VacationDbContext _context;

        public PaidTimeOffController(VacationDbContext context) : base(context, context.PaidTimeOffs)
        {

            _context = context;

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
            BaseTimeOff timeOff = context.PaidTimeOffs.Find(id);
            timeOff.IsApproved = true;
            context.SaveChanges();
            context.Dispose();

            return RedirectToAction("../TimeOffs/Index");
        }

    }
}
