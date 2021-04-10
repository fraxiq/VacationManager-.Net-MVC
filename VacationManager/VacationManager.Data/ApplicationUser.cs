using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace VacationManager.Data
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; } = new HashSet<IdentityUserRole<string>>();

       
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
