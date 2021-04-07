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

            base.OnModelCreating(builder);
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

        }
    }
}
