using MSESoftware.JWTProject.DataAccess.Interfaces;
using MSESoftware.JWTProject.Entities.Concrete;

namespace MSESoftware.JWTProject.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EFAppUserRepository : EFGenericRepository<AppUser>, IAppUserDal
    {
    }
}
