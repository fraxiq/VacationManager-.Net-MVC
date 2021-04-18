using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VacationManager.Data;
using VacationManager.Data.Data;
using VacationManager.Web.Models;

namespace VacationManager.Controllers
{
    public class TeamsController : Controller
    {
        private readonly VacationDbContext _context;

        public TeamsController(VacationDbContext context)
        {
            _context = context;
        }

        // GET: Teams
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Teams.ToListAsync());
        }

        // GET: Teams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams.Include(c => c.TeamLead)
                .FirstOrDefaultAsync(m => m.ID == id);
            

            if (team == null)
            {
                return NotFound();
            }

            var teamDevs = _context.TeamDevelopers.Include(c => c.Developer).Where(c => c.TeamId == id).ToList();

            var model = new TeamViewModel
            {
                TeamDevelopers = teamDevs,
                Team = team
            };

            return View(model);
        }

        // GET: Teams/Create
        public IActionResult Create()
        {
            var model = new CreateTeamViewModel();
            var users = _context.Users.ToList();
            model.TeamLeads  = users.Select(c => new SelectListItem { Text = c.UserName, Value = c.Id});
           ViewBag.Developers = users.Select(c => new SelectListItem { Text = c.UserName, Value = c.Id });


            return View(model);
        }

        // POST: Teams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTeamViewModel model)
        {
            if (ModelState.IsValid)
            {
                var devs = model.Developers.Select(c => _context.Users.FirstOrDefault(u => u.Id == c)).ToList();
                var team = new Team()
                {
                    Developers = devs,
                    TeamLeadID = model.TeamLeadId,
                    TeamName = model.TeamName

                };
                 _context.Add(team);
                await _context.SaveChangesAsync();

                var teamsDevelopers = devs.Select(c => new TeamDevelopers
                {
                    DeveloperId = c.Id,
                    TeamId = team.ID
                });

                _context.AddRange(teamsDevelopers);
                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Teams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            return View(team);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TeamName")] Team team)
        {
            if (id != team.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(team);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExists(team.ID))
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
            return View(team);
        }

        // GET: Teams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .FirstOrDefaultAsync(m => m.ID == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.ID == id);
        }
    }
}
