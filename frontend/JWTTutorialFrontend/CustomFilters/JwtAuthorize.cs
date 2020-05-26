using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using JWTTutorialFrontend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace JWTTutorialFrontend.CustomFilters
{
    public class JwtAuthorize : ActionFilterAttribute
    {
        public string Roles { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var token = context.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = httpClient.GetAsync("http://localhost:61681/api/Auth/CurrentUser").Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var activeUser = JsonConvert.DeserializeObject<AppUser>(response.Content.ReadAsStringAsync().Result);
                    if (!string.IsNullOrWhiteSpace(Roles))
                    {

                        bool accessStatus = false;

                        if (Roles.Contains(","))
                        {
                            var acceptedRoles = Roles.Split(",");
                            foreach (var role in acceptedRoles)
                            {
                                if (activeUser.Roles.Contains(role))
                                {
                                    accessStatus = true;
                                }
                            }
                        }
                        else
                        {
                            if (activeUser.Roles.Contains(Roles))
                            {
                                accessStatus = true;
                            }
                        }
                        if (accessStatus == false)
                        {
                            context.Result = new RedirectToActionResult("AccessDenied", "Account", null);
                        }
                    }

                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    context.HttpContext.Session.Remove("token");
                    context.Result = new RedirectToActionResult("SignIn", "Account", null);
                }
                else
                {
                    var statusCode = response.StatusCode.ToString();
                    context.HttpContext.Session.Remove("token");
                    context.Result = new RedirectToActionResult("ApiError", "Account", new { code = statusCode });
                }
            }
            else
            {
                context.Result = new RedirectToActionResult("SignIn", "Account", null);
            }
        }
    }
}