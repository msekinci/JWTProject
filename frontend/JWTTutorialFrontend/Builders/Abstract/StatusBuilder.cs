using JWTTutorialFrontend.Builders.Concrete;
using JWTTutorialFrontend.Models;

namespace JWTTutorialFrontend.Builders.Abstract{
    public abstract class StatusBuilder{
        public abstract Status GenerateStatus(AppUser activeUser, string roles);
    }
}