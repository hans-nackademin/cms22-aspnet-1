using Microsoft.AspNetCore.Mvc;

namespace _02_ProfileAndImageUpload.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
