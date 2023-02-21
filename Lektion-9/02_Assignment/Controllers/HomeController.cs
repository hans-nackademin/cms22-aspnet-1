using Microsoft.AspNetCore.Mvc;

namespace _02_Assignment.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
