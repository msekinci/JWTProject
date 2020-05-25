using MSESoftware.JWTProject.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSESoftware.JWTProject.DataAccess.Interfaces
{
    public interface IAppUserDal : IGenericDal<AppUser>
    {
        Task<List<AppRole>> GetRolesByUserName(string userName);
    }
}
