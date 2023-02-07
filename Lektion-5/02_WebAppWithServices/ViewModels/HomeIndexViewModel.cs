using _02_WebAppWithServices.Models.Partials;
using _02_WebAppWithServices.Services;
using Newtonsoft.Json;

namespace _02_WebAppWithServices.ViewModels
{
    public class HomeIndexViewModel : BaseViewModel
    {
        public ShowcaseModel Showcase { get; set; } = null!;
        public Guid Id { get; set; }
        

    }
}
