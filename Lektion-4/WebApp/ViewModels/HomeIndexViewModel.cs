using WebApp.ViewModels.Products;

namespace WebApp.ViewModels
{
    public class HomeIndexViewModel
    {
        public string Title { get; set; } = "Home";
        public ProductGridViewModel FeaturedProducts { get; set; } = new ProductGridViewModel();
        public ProductGridViewModel NewProducts { get; set; } = new ProductGridViewModel();
        public ProductGridViewModel PopularProducts { get; set; } = new ProductGridViewModel();
    }
}
