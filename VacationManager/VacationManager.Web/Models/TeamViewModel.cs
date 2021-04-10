using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VacationManager.Data;

namespace VacationManager.Web.Models
{
    public class TeamViewModel
    {
        public Team Team { get; set; }
        public IEnumerable<TeamDevelopers> TeamDevelopers { get; set; }
    }
}
