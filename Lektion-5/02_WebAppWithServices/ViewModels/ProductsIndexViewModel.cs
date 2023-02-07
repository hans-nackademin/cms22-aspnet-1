using _02_WebAppWithServices.Models.Partials;

namespace _02_WebAppWithServices.ViewModels
{
    public class ProductsIndexViewModel : BaseViewModel
    {
        public ShowcaseModel Showcase { get; set; } = null!;
        public Guid Id { get; set; }
    }
}
