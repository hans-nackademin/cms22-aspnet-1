using Microsoft.AspNetCore.Mvc;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var viewModel = new HomeIndexViewModel();
            
            using var http = new HttpClient();
            viewModel.BestCollection = await http.GetFromJsonAsync<IEnumerable<CardViewModel>>("https://localhost:7228/api/products/Best Collection/1");
            viewModel.NewProducts = await http.GetFromJsonAsync<IEnumerable<CardViewModel>>("https://localhost:7228/api/products/New/1");
            viewModel.PopularProducts = await http.GetFromJsonAsync<IEnumerable<CardViewModel>>("https://localhost:7228/api/products/Popular/1");

            return View(viewModel);
        }
    }
}
