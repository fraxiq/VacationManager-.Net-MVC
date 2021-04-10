
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace VacationManager.Data.Data.Seed
{
    public class UsersSeeder : ISeeder
    {
        public async Task SeedAsync(DbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var db = dbContext as VacationDbContext;

            if (!db.Users.Any())
            {
                var adminUser = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@admin.com"
                };

                var user = new ApplicationUser
                {
                    UserName = "user",
                    Email = "user@admin.com"

                };

                await userManager.CreateAsync(adminUser, "Admin123!");
                await userManager.CreateAsync(user, "User123!");
                await userManager.AddToRoleAsync(adminUser, "CEO");
                await userManager.AddToRoleAsync(user, "Unassigned");
            }
        }
    }
}
