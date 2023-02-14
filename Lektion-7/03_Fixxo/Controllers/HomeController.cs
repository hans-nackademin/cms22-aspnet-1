using _03_Fixxo.Services;
using _03_Fixxo.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace _03_Fixxo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductService _productService;
        private readonly ShowcaseService _showcaseService;

        public HomeController(ProductService productService, ShowcaseService showcaseService)
        {
            _productService = productService;
            _showcaseService = showcaseService;
        }


        public async Task<IActionResult> Index()
        {
            var viewModel = new IndexViewModel();
            viewModel.Products = await _productService.GetProducts();
            viewModel.Showcase = await _showcaseService.GetLatestShowcase();

            ViewData["Title"] = viewModel.PageTitle;
            return View(viewModel);
        }
    }
}
