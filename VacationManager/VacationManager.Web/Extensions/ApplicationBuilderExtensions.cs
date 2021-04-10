using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using VacationManager.Data.Data.Seed;

namespace VacationManager.Web.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder Initialize<T>(
            this IApplicationBuilder app,
            List<ISeeder> seeders = null) where T : DbContext
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var serviceProvider = serviceScope.ServiceProvider;

            var db = serviceProvider.GetRequiredService<T>();

            if (seeders != null)
            {
                foreach (var seeder in seeders)
                {
                    seeder.SeedAsync(db, serviceProvider).GetAwaiter().GetResult();
                }
            }

            return app;
        }
    }
}
