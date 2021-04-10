using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VacationManager.Data
{
    public class Team 
    {
        public Team()
        {
            this.Developers = new HashSet<ApplicationUser>();
            
        }

        [Key]
        public int ID { get; set; }     
        public string TeamName { get; set; }
        public virtual ICollection<ApplicationUser> Developers { get; set; }
        public string TeamLeadID { get; set; }
        public virtual ApplicationUser TeamLead { get; set; }

        public int? ProjectID { get; set; }
        public virtual Project? Project { get; set; }

    }
}
