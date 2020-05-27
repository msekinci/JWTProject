using JWTTutorialFrontend.Builders.Abstract;
using JWTTutorialFrontend.Models;

namespace JWTTutorialFrontend.Builders.Concrete
{
    public class SingleRoleStatusBuilder : StatusBuilder
    {
        public override Status GenerateStatus(AppUser activeUser, string roles)
        {
            Status status = new Status();

            if (activeUser.Roles.Contains(roles))
            {
                status.AccessStatus = true;
            }
            return status;
        }
    }
}