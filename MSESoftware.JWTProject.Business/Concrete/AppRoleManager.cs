using MSESoftware.JWTProject.Business.Interfaces;
using MSESoftware.JWTProject.DataAccess.Interfaces;
using MSESoftware.JWTProject.Entities.Concrete;

namespace MSESoftware.JWTProject.Business.Concrete
{
    public class AppRoleManager : GenericManager<AppRole>, IAppRoleService
    {
        public AppRoleManager(IGenericDal<AppRole> genericDal) : base(genericDal)
        {

        }
    }
}
