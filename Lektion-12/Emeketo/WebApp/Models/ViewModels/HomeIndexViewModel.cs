using WebApp.Models.Entitites;

namespace WebApp.Models.ViewModels
{
    public class HomeIndexViewModel
    {
        public ProductCollectionViewModel BestCollection { get; set; } = null!;
        public ShowcaseEntity Showcase { get; set; } = null!;
    }
}
