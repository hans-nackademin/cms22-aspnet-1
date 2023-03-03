using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Entitites;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new HomeIndexViewModel();
            viewModel.Showcase = new ShowcaseEntity
            {
                Title_1 = "WELLCOME TO bmarketo SHOP",
                Title_2 = "Exclusive Chair gold Collection. ",
                ImageName = "~/images/placeholders/625x647.png"
            };
            viewModel.BestCollection = new ProductCollectionViewModel
            {
                Title = "Best Collection"
            };


            return View(viewModel);
        }
    }
}
