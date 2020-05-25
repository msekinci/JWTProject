using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MSESoftware.JWTProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        [Route("/Error")]
        public IActionResult Error()
        {
            var errorInfo = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            // Burada Log'lama işlemlerimizi yapabiliriz
            //var message = errorInfo.Error.Message;
            return Problem(detail: "A problem occured. We will review and fix soon.");
        }
    }
}