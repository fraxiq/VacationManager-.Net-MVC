using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace VacationManager.Data.Data.Seed
{
    public interface ISeeder
    {
        Task SeedAsync(DbContext dbContext, IServiceProvider serviceProvider);
    }
}
