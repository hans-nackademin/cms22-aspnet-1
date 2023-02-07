using _02_WebAppWithServices.Models.Partials;
using _02_WebAppWithServices.Services;
using _02_WebAppWithServices.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _02_WebAppWithServices.Controllers
{
    public class ProductsController : Controller
    {
        private readonly FileService _fileService;
        private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment _env;

        public ProductsController(FileService fileService, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {
            _env = env;
            _fileService = fileService;
            
            
        }

        public IActionResult Index()
        {
            _fileService.FilePath = @$"{_env.WebRootPath}\Data\products_showcase.json";

            var viewModel = new ProductsIndexViewModel();
            viewModel.Showcase = JsonConvert.DeserializeObject<ShowcaseModel>(_fileService.Read())!;
            viewModel.Id = _fileService.Id;


            return View(viewModel);
        }
    }
}
