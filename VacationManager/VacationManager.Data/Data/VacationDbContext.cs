using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace VacationManager.Data.Data
{
    public class VacationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
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
                .WillCascadeOnDelete(false);

            builder.Entity<Team>()
                .HasOne(t => t.TeamLead)
                .WithMany(u => u.LedTeams)
                .WillCascadeOnDelete(false);

            builder.Entity<Project>()
                .HasMany(p => p.Teams)
                .WithOptional(t => t.Project)
                .WillCascadeOnDelete(false);

            builder.Entity<Role>()
                .HasMany(r => r.Users)
                .WithRequired(u => u.Role)
                .WillCascadeOnDelete(false);

            List<IdentityRole> roles = new List<IdentityRole>()
             {
               new IdentityRole { Name = "CEO", NormalizedName = "CEO" },
               new IdentityRole { Name = "Developer", NormalizedName = "Developer" },
               new IdentityRole { Name = "Team Lead", NormalizedName = "Team Lead" },
               new IdentityRole { Name = "Unassigned", NormalizedName = "Unassigned" }
             };

            builder.Entity<IdentityRole>().HasData(roles);
            builder.Entity<Team>().HasMany<ApplicationUser>();
            builder.Entity<Team>().HasOne<Project>();
            builder.Entity<Project>().HasMany<Team>();

            base.OnModelCreating(builder);
        }
        public virtual DbSet<Team> Teams { get; set; }

        public virtual DbSet<ApplicationUser> Users { get; set; }

        public virtual DbSet<Project> Projects { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        //public virtual DbSet<PaidTimeOff> PaidTimeOffs { get; set; }

        //public virtual DbSet<UnpaidTimeOff> UnpaidTimeOffs { get; set; }

        //public virtual DbSet<SickTimeOff> SickTimeOffs { get; set; }
    }
}
