using _02_WebAppWithServices.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _02_WebAppWithServices.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new HomeIndexViewModel();

            return View(viewModel);
        }
    }
}
