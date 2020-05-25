using MSESoftware.JWTProject.Entities.Concrete;
using MSESoftware.JWTProject.Entities.DTOs.AppUserDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSESoftware.JWTProject.Business.Interfaces
{
    public interface IAppUserService : IGenericService<AppUser>
    {
        Task<AppUser> FindByUserName(string userName);
        Task<bool> CheckPassword(AppUserSignInDTO appUserSignInDTO);
        Task<List<AppRole>> GetRolesByUserName(string userName);
    }
}
