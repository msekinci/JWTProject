using MSESoftware.JWTProject.Business.Interfaces;
using MSESoftware.JWTProject.DataAccess.Interfaces;
using MSESoftware.JWTProject.Entities.Concrete;

namespace MSESoftware.JWTProject.Business.Concrete
{
    public class AppUserRoleManager : GenericManager<AppUserRole>, IAppUserRoleService
    {
        public AppUserRoleManager(IGenericDal<AppUserRole> genericDal) : base(genericDal)
        {

        }
    }
}
