using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VacationManager.Data;

namespace VacationManager.Web.Models
{
    public class ProjectViewModel
    {
        public Project Project { get; set; }
        public IEnumerable<ProjectTeams> ProjectTeams { get; set; }
    }
}
