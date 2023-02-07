using Microsoft.AspNetCore.Mvc;

namespace _00_Repetition.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
