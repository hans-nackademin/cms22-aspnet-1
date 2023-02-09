using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Contexts;
using WebApp.Models;
using WebApp.Models.Entities;
using WebApp.Services;
using WebApp.ViewModels.Home;

namespace WebApp.Controllers
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
