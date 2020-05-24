using Microsoft.EntityFrameworkCore;
using MSESoftware.JWTProject.DataAccess.Concrete.EntityFrameworkCore.Context;
using MSESoftware.JWTProject.DataAccess.Interfaces;
using MSESoftware.JWTProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MSESoftware.JWTProject.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EFGenericRepository<T> : IGenericDal<T> where T : class, IEntity, new()
    {
        public async Task AddAsync(T entity)
        {
            using var context = new JWTContext();
            context.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            using var context = new JWTContext();
            return await context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAllByFilterAsync(Expression<Func<T, bool>> filter)
        {
            using var context = new JWTContext();
            return await context.Set<T>().Where(filter).ToListAsync();
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            using var context = new JWTContext();
            return await context.Set<T>().FirstOrDefaultAsync(filter);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            using var context = new JWTContext();
            return await context.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            using var context = new JWTContext();
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            using var context = new JWTContext();
            context.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
