using MSESoftware.JWTProject.DataAccess.Interfaces;
using MSESoftware.JWTProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSESoftware.JWTProject.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EFAppUserRoleRepository : EFGenericRepository<AppUserRole>, IAppUserRoleDal
    {
    }
}
