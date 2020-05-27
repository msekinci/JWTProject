using System.Net.Http;
using System.Net.Http.Headers;
using JWTTutorialFrontend.Builders.Concrete;
using JWTTutorialFrontend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace JWTTutorialFrontend.CustomFilters
{
    public class JwtAuthorizeHelper
    {
        /// <summary>
        /// Check Role of Active User
        /// </summary>
        public static void CheckUserRole(AppUser activeUser, string roles, ActionExecutingContext context)
        {
            if (!string.IsNullOrWhiteSpace(roles))
            {
                Status status = null;
                if (roles.Contains(","))
                {
                    StatusBuilderDirector director = new StatusBuilderDirector(new MultiRoleStatusBuilder());
                    status = director.GenerateStatus(activeUser, roles);
                }
                else
                {
                    StatusBuilderDirector director = new StatusBuilderDirector(new SingleRoleStatusBuilder());
                    status = director.GenerateStatus(activeUser, roles);
                }
                CheckStatus(status, context);
            }
        }

        /// <summary>
        /// Check access status of role
        /// </summary>
        private static void CheckStatus(Status status, ActionExecutingContext context)
        {
            if (!status.AccessStatus)
            {
                context.Result = new RedirectToActionResult("AccessDenied", "Account", null);
            }
        }

        /// <summary>
        /// Get active user who sign in
        /// </summary>
        public static AppUser GetActiveUser(HttpResponseMessage httpResponse)
        {
            return JsonConvert.DeserializeObject<AppUser>(httpResponse.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Check session for token 
        /// </summary>
        public static bool CheckToken(ActionExecutingContext context, out string token)
        {
            token = context.HttpContext.Session.GetString("token");
            if (string.IsNullOrWhiteSpace(token))
            {
                context.Result = new RedirectToActionResult("SignIn", "Account", null);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Request to API with token to get active user
        /// </summary>
        public static HttpResponseMessage GetActiveUserResponse(string token)
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return httpClient.GetAsync("http://localhost:61681/api/Auth/CurrentUser").Result;
        }
    }
}