using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VacationManager.Data
{
    public class Team 
    {
        public Team()
        {
            this.Users = new HashSet<ApplicationUser>();
            this.Projects = new HashSet<Project>();
        }

        [Key]
        public int ID { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public string TeamName { get; set; }
        


    }
}
