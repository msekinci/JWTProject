using System.Collections.Generic;
using System.Threading.Tasks;
using JWTTutorialFrontend.Models;

namespace JWTTutorialFrontend.APIServices.Interfaces{
    public interface IProductService
    {
        Task<List<ProductList>> GetAllAsync();
        Task<ProductList> GetByIdAsync(int id);

        Task AddAsync(ProductAdd product);
        Task UpdateAsync(ProductUpdate product);
        Task DeleteAsync(int id);
    }
}