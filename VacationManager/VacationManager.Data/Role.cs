using System;
using System.Collections.Generic;
using System.Text;

namespace VacationManager.Data
{
    public class Role
    {
        public Role()
        {
            this.Users = new HashSet<ApplicationUser>();
        }

        public Role(string name) : this()
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
