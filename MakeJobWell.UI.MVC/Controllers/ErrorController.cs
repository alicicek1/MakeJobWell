using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MakeJobWell.UI.MVC.Controllers
{
    public class ErrorController : Controller
    {
        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            ViewBag.Path = exception.Path;
            ViewBag.Message = exception.Error.Message;
            return View();
        }

        public IActionResult CustomError()
        {
            return View();
        }
    }
}
