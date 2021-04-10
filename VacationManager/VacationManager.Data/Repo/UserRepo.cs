using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VacationManager.Data.Data;

namespace VacationManager.Data
{
    class UserRepo
    {
        public class UserRepository
        {
            private readonly VacationDbContext _dbContext;

            public UserRepository(VacationDbContext dbContext)
            {
                this._dbContext = dbContext;
            }

            public IQueryable<ApplicationUser> GetAll()
            {
                return this._dbContext.Users.AsQueryable();
            }

            public IQueryable<ApplicationUser> GetAll(Expression<Func<ApplicationUser, bool>> predicate)
            {
                return this._dbContext.Users.Where(predicate).AsQueryable();
            }

            public ApplicationUser GetOne(int id)
            {
                return this._dbContext.Users.Find(id);
            }

            public ApplicationUser GetOne(Expression<Func<ApplicationUser, bool>> predicate)
            {
                return this._dbContext.Users.FirstOrDefault(predicate);
            }

            public void Add(ApplicationUser entity)
            {
                this._dbContext.Users.Add(entity);
                this._dbContext.SaveChanges();
            }

            public void Update(ApplicationUser entity)
            {
                this._dbContext.Entry(entity).State = EntityState.Modified;
                this._dbContext.SaveChanges();
            }

            public void Remove(ApplicationUser entity)
            {
                this._dbContext.Users.Remove(entity);
                this._dbContext.SaveChanges();
            }

            public int Count()
            {
                return this._dbContext.Users.Count();
            }

            public int Count(Expression<Func<ApplicationUser, bool>> predicate)
            {
                return this._dbContext.Users.Count(predicate);
            }
        }
    }
}
