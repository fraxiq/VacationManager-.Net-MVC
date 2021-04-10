using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VacationManager.Data;
using VacationManager.Data.Data;

[assembly: HostingStartup(typeof(VacationManager.Web.Areas.Identity.IdentityHostingStartup))]
namespace VacationManager.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            //builder.ConfigureServices((context, services) => {
            //    services.AddDbContext<VacationDbContext>(options =>
            //        options.UseSqlServer(
            //            context.Configuration.GetConnectionString("DatabaseConnection")));

            //    services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //        .AddEntityFrameworkStores<VacationDbContext>();
            //});
        }
    }
}