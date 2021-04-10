using System.ComponentModel.DataAnnotations;

namespace VacationManager.Data
{
    public class ProjectTeams
    {
        [Key]
        public int Id { get; set; }

        public int TeamID { get; set; }
        public virtual Team Team { get; set; }
        public int ProjectID { get; set; }
        public virtual Project Project { get; set; }
    }
}
