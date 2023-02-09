using WebApp.Models;

namespace WebApp.ViewModels.Home
{
    public class IndexViewModel
    {
        public string PageTitle { get; set; } = "Home";
        public ShowcaseModel Showcase { get; set; } = new ShowcaseModel();
        public IEnumerable<ProductModel> Products { get; set; } = new List<ProductModel>();
    }
}
