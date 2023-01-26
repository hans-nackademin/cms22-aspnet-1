using ConsoleApp.Models;

namespace ConsoleApp.ViewModels
{
    public class HomeViewModel
    {
        public string Title { get; set; } = "Welcome to Fixxo";
        public List<ProductModel> FeaturedProducts { get; set; } = null!;
        public List<ProductModel> NewProducts { get; set; } = null!;
        public List<ProductModel> PopularProducts { get; set; } = null!;
    }
}
