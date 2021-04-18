using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VacationManager.Data.TimeOff;


namespace VacationManager.Data.Data
{
    public class VacationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public VacationDbContext()
        {

        }
        public VacationDbContext(DbContextOptions<VacationDbContext> options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>()
                .HasOne(u => u.Team)
                .WithMany(t => t.Developers)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Team>()
                .HasOne(t => t.TeamLead)
                .WithMany(u => u.LedTeams)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Project>()
                .HasMany(p => p.Teams)
                .WithOne(t => t.Project)
                .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(builder);
            builder.Entity<TeamDevelopers>()
            .HasKey(t => new { t.TeamId, t.DeveloperId });
            builder.Entity<ProjectTeams>()
           .HasKey(t => new { t.TeamID, t.ProjectID }); ;


        }
        public virtual DbSet<Team> Teams { get; set; }

        public virtual DbSet<ApplicationUser> Users { get; set; }

        public virtual DbSet<Project> Projects { get; set; }

        public virtual DbSet<TeamDevelopers> TeamDevelopers { get; set; }
        public virtual DbSet<ProjectTeams> ProjectTeams { get; set; }
        public virtual DbSet<PaidTimeOff> PaidTimeOffs { get; set; }

        public virtual DbSet<UnpaidTimeOff> UnpaidTimeOffs { get; set; }

        public virtual DbSet<SickTimeOff> SickTimeOffs { get; set; }
    }
}
