using System.Collections.Generic;

namespace VacationManager.Web.Models
{
    public class CreateProjectViewModel
    {
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<int> Teams { get; set; }

    }
}
