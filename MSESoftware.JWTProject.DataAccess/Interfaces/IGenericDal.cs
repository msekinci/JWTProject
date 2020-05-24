using MSESoftware.JWTProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MSESoftware.JWTProject.DataAccess.Interfaces
{
    public interface IGenericDal<T> where T : class, IEntity, new()
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllByFilterAsync(Expression<Func<T, bool>> filter);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);
        Task UpdateAsync(T entity);
        Task AddAsync(T entity);
        Task RemoveAsync(T entity);
    }
}
