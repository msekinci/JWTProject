using System.Threading.Tasks;
using JWTTutorialFrontend.APIServices.Interfaces;
using JWTTutorialFrontend.Models;
using Microsoft.AspNetCore.Mvc;

namespace JWTTutorialFrontend.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;
        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserSignIn appUserSignIn)
        {
            if (ModelState.IsValid)
            {
                if (await _authService.SignIn(appUserSignIn))
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Please double check your username and password");
            }
            return View(appUserSignIn);
        }
    }
}