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
            this.Teams = new HashSet<Team>();

        }
        public virtual ICollection<Team> Teams { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
    }
}
