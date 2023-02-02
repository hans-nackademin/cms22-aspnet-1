using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new HomeIndexViewModel();
            viewModel.FeaturedProducts = new ViewModels.Products.ProductGridViewModel
            {
                Title = "Featured Products",
                Items = new List<Models.Products.ProductModel> { new Models.Products.ProductModel() 
                { 
                    Category = "Fashion",
                    Tag = "featured",
                    Name = "Blue Jacket",
                    ImageUrl = "~/images/blue-jacket.png",
                    Description = "some text goes here",
                    Price = 1000,
                    Rating = 4,
                    Vendor = "Blue"
                }}
            };


            return View(viewModel);
        }
    }
}
