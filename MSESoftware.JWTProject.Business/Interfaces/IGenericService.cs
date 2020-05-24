using MSESoftware.JWTProject.Entities.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSESoftware.JWTProject.Business.Interfaces
{
    public interface IGenericService<T> where T:class, IEntity, new()
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(T entity);
        Task AddAsync(T entity);
        Task RemoveAsync(T entity);
    }
}
