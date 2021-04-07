using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VacationManager.Data
{
    public class Project
    {
        public Project()
        {
            this.Teams = new HashSet<Team>();

        }

        [Key]
        public int ID { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        //public List<Team> Teams { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }

    }
}
