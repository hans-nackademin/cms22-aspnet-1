using WebApp.Models.Products;

namespace WebApp.ViewModels.Products
{
    public class ProductGridViewModel
    {
        public string Title { get; set; } = string.Empty;
        public int Columns { get; set; } = 4;
        public List<ProductModel> Items { get; set; } = new List<ProductModel>();
    }
}
