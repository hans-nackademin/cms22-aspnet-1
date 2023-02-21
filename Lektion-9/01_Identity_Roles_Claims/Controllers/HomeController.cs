using Microsoft.AspNetCore.Mvc;

namespace _01_Identity_Roles_Claims.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
