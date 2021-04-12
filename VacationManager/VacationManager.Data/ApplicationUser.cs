using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using VacationManager.Data.TimeOff;

namespace VacationManager.Data
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.LedTeams = new HashSet<Team>();
            this.PaidTimeOffRequests = new HashSet<PaidTimeOff>();
            this.UnpaidTimeOffRequests = new HashSet<UnpaidTimeOff>();
            this.SickTimeOffRequests = new HashSet<SickTimeOff>();
        }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; } = new HashSet<IdentityUserRole<string>>();

       
        public string FirstName { get; set; }
        public string LastName { get; set; }       
        public virtual Team Team { get; set; }
        public virtual ICollection<Team> LedTeams { get; set; }
        public virtual ICollection<PaidTimeOff> PaidTimeOffRequests { get; set; }

        public virtual ICollection<UnpaidTimeOff> UnpaidTimeOffRequests { get; set; }

        public virtual ICollection<SickTimeOff> SickTimeOffRequests { get; set; }
    }
}
