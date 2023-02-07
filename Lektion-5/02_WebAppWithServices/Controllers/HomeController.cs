using _02_WebAppWithServices.Models.Partials;
using _02_WebAppWithServices.Services;
using _02_WebAppWithServices.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _02_WebAppWithServices.Controllers
{
    public class HomeController : Controller
    {
        private readonly FileService _fileService;

        public HomeController(FileService fileService)
        {
            _fileService = fileService;
        }

        public IActionResult Index()
        {
            var viewModel = new HomeIndexViewModel();
            viewModel.Showcase = JsonConvert.DeserializeObject<ShowcaseModel>(_fileService.Read())!;
            viewModel.Id = _fileService.Id;

            return View(viewModel);
        }
    }
}
