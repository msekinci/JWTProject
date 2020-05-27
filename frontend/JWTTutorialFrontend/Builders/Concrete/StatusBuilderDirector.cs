using JWTTutorialFrontend.Builders.Abstract;
using JWTTutorialFrontend.Models;

namespace JWTTutorialFrontend.Builders.Concrete{
    public class StatusBuilderDirector{
        private StatusBuilder builder;
        public StatusBuilderDirector(StatusBuilder builder)
        {
            this.builder = builder;
        }

        public Status GenerateStatus(AppUser appUser, string roles){
            return builder.GenerateStatus(appUser,roles);
        }
    }
}