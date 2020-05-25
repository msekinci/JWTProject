using MSESoftware.JWTProject.Business.Interfaces;
using MSESoftware.JWTProject.DataAccess.Concrete.EntityFrameworkCore.Context;
using MSESoftware.JWTProject.DataAccess.Interfaces;
using MSESoftware.JWTProject.Entities.Concrete;
using MSESoftware.JWTProject.Entities.DTOs.AppUserDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSESoftware.JWTProject.Business.Concrete
{
    public class AppUserManager : GenericManager<AppUser>, IAppUserService
    {
        private readonly IAppUserDal _appUserDal;
        public AppUserManager(IGenericDal<AppUser> genericDal, IAppUserDal appUserDal) : base(genericDal)
        {
            _appUserDal = appUserDal;
        }

        public async Task<bool> CheckPassword(AppUserSignInDTO appUserSignInDTO)
        {
            var user = await _appUserDal.GetByFilterAsync(x => x.UserName == appUserSignInDTO.UserName && x.Password == appUserSignInDTO.Password);
            return user == null ? false : true;
        }

        public async Task<AppUser> FindByUserName(string userName)
        {
            var user = await _appUserDal.GetByFilterAsync(x => x.UserName == userName);
            return user == null ? null : user;
        }

        public async Task<List<AppRole>> GetRolesByUserName(string userName)
        {
            return await _appUserDal.GetRolesByUserName(userName);
        }
    }
}
