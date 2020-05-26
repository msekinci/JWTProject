using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using JWTTutorialFrontend.APIServices.Interfaces;
using JWTTutorialFrontend.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace JWTTutorialFrontend.APIServices.Concrete{
    public class AuthManager : IAuthService
    {
        private readonly IHttpContextAccessor _httpContext;
        public AuthManager(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        //HTTPContext: Startup'da aç

        public async Task<bool> SignIn(AppUserSignIn appUserSignIn)
        {
            string jsonData = JsonConvert.SerializeObject(appUserSignIn);
            var stringContent = new StringContent
            (
                jsonData, Encoding.UTF8, "application/json"
            );

            using var htttpClient = new HttpClient();
            var response = await htttpClient.PostAsync("http://localhost:61681/api/Auth/SignIn", stringContent);

            if (response.IsSuccessStatusCode)
            {
                var token = JsonConvert.DeserializeObject<AccessToken>(await response.Content.ReadAsStringAsync());
                _httpContext.HttpContext.Session.SetString("token", token.Token);
                return true;
            }
            return false;
        }

        public void SignOut()
        {
            _httpContext.HttpContext.Session.Remove("token");
        }
    }
}