using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VacationManager.Data;
using VacationManager.Data.Data;

namespace VacationManager.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            

            services.AddDbContext<VacationDbContext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection")));
            services.AddControllersWithViews();
            services.AddIdentityCore<ApplicationUser>()
        .AddEntityFrameworkStores<VacationDbContext>();

            services.BuildServiceProvider().GetService<VacationDbContext>().Database.EnsureCreated();
            var context = services.BuildServiceProvider().GetService<VacationDbContext>();

            string[] roles = new string[] { "CEO", "Developer", "Team Lead", "Unassigned" };

            var roleStore = new RoleStore<IdentityRole>(context);

            //if (!context.Roles.Any(r => r.Name == "CEO"))
            //{
            //    var store = new RoleStore<IdentityRole>(context);
            //    var manager = new RoleManager<IdentityRole>(store);
            //    var adminRole = new IdentityRole { Name = "Admin" };

            //    manager.Create(adminRole);
            //    roleStore.CreateAsync(new IdentityRole("Unassigned"));
            //    roleStore.CreateAsync(new IdentityRole("CEO"));
            //    roleStore.CreateAsync(new IdentityRole("Developer"));
            //    roleStore.CreateAsync(new IdentityRole("Team Lead"));         
            //}

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
