using System.Threading.Tasks;
using JWTTutorialFrontend.Models;

namespace JWTTutorialFrontend.APIServices.Interfaces{
    public interface IAuthService
    {
        Task<bool> SignIn(AppUserSignIn appUserSignIn);
        void SignOut();
    }
}