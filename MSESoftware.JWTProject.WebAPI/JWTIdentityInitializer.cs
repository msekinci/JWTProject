using MSESoftware.JWTProject.Business.Interfaces;
using MSESoftware.JWTProject.Business.StringInfos;
using MSESoftware.JWTProject.Entities.Concrete;
using System.Threading.Tasks;

namespace MSESoftware.JWTProject.WebAPI
{
    public static class JWTIdentityInitializer
    {
        public static async Task Seed(IAppUserService appUserService, IAppUserRoleService appUserRoleService, IAppRoleService appRoleService)
        {
            //İlgili role var mı?
            var adminRole = await appRoleService.FindByName(RoleInfo.Admin);
            if (adminRole == null)
            {
                await appRoleService.AddAsync(new AppRole { Name = RoleInfo.Admin });
            }

            var memberRole = await appRoleService.FindByName(RoleInfo.Member);
            if (memberRole == null)
            {
                await appRoleService.AddAsync(new AppRole { Name = RoleInfo.Member });
            }

            //Admin kullanıcısı var mı?
            var adminUser = await appUserService.FindByUserName("msekinci");
            if (adminUser == null)
            {
                await appUserService.AddAsync(new AppUser
                {
                    UserName = "msekinci",
                    FullName = "Mehmet Serkan Ekinci",
                    Password = "1"
                });

                var role = await appRoleService.FindByName(RoleInfo.Admin);
                var user = await appUserService.FindByUserName("msekinci");

                await appUserRoleService.AddAsync(new AppUserRole
                {
                    AppUserId = user.Id,
                    AppRoleId = role.Id
                });
            }
        }
    }
}
