using System.ComponentModel.DataAnnotations;

namespace VacationManager.Data
{
    public class TeamDevelopers
    {
        [Key]
        public int Id { get; set; }

        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        public string DeveloperId { get; set; }
        public virtual ApplicationUser Developer { get;set; }

    }
}
