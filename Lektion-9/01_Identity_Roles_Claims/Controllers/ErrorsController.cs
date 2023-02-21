using Microsoft.AspNetCore.Mvc;

namespace _01_Identity_Roles_Claims.Controllers
{
    public class ErrorsController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
