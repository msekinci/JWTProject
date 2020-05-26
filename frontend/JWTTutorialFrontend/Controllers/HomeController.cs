using Microsoft.AspNetCore.Mvc;

namespace JWTTutorialFrontend.Controllers{
    public class HomeController : Controller{

        public IActionResult Index(){
            return View();
        }

    }
}