
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
                    Email = "admin@admin.com",
                    FirstName = "Alexander",
                    LastName = "Stankov"
                    
                };

                var user1 = new ApplicationUser
                {
                    UserName = "user1",
                    Email = "user1@admin.com",
                    FirstName = "Martin",
                    LastName = "Ivanov"

                };
                var user2 = new ApplicationUser
                {
                    UserName = "user2",
                    Email = "user2@admin.com",
                    FirstName = "Petar",
                    LastName = "Dimitrov"
                };
                var user3 = new ApplicationUser
                {
                    UserName = "user3",
                    Email = "user3@admin.com",
                    FirstName = "Dimitar",
                    LastName = "Jekov"
                };
                var user4 = new ApplicationUser
                {
                    UserName = "user4",
                    Email = "user4@admin.com",
                    FirstName = "Kristiqn",
                    LastName = "Stoikov"
                };
                var user5 = new ApplicationUser
                {
                    UserName = "user5",
                    Email = "user5@admin.com",
                    FirstName = "Ivanina",
                    LastName = "Stankova"
                };
                var user6 = new ApplicationUser
                {
                    UserName = "user6",
                    Email = "user6@admin.com",
                    FirstName = "Debora",
                    LastName = "Dimitrova"
                };

                await userManager.CreateAsync(adminUser, "Admin123!");
                await userManager.CreateAsync(user1, "User1!");
                await userManager.AddToRoleAsync(adminUser, "CEO");
                await userManager.AddToRoleAsync(user1, "Developer");
                await userManager.CreateAsync(user2, "User2!");
                await userManager.CreateAsync(user3, "User3!");
                await userManager.AddToRoleAsync(user2, "Developer");
                await userManager.AddToRoleAsync(user3, "Developer");
                await userManager.CreateAsync(user4, "User4!");
                await userManager.CreateAsync(user5, "User5!");
                await userManager.AddToRoleAsync(user4, "Developer");
                await userManager.AddToRoleAsync(user5, "Developer");
                await userManager.CreateAsync(user6, "User6!");                
                await userManager.AddToRoleAsync(user6, "Unassigned");
                
            }
        }
    }
}
