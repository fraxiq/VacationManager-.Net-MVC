using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace VacationManager.Data
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.LedTeams = new HashSet<Team>();

        }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Team> LedTeams { get; set; }
        public virtual Team Team { get; set; }


    }
}
