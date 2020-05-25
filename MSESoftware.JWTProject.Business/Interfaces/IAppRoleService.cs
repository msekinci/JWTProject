using MSESoftware.JWTProject.Entities.Concrete;
using System.Threading.Tasks;

namespace MSESoftware.JWTProject.Business.Interfaces
{
    public interface IAppRoleService : IGenericService<AppRole>
    {
        Task<AppRole> FindByName(string roleName); 
    }
}
