using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VacationManager.Web.Models
{
    public class EditTeamViewModel
    {
        public string TeamName { get; set; }
        public IEnumerable<SelectListItem> TeamLeads { get; set; }
        public IEnumerable<string> Developers { get; set; }
        public string TeamLeadId { get; set; }
    }
}
