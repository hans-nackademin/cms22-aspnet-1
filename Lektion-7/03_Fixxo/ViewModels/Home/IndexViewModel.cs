using _03_Fixxo.Models;

namespace _03_Fixxo.ViewModels.Home
{
    public class IndexViewModel
    {
        public string PageTitle { get; set; } = "Home";
        public ShowcaseModel Showcase { get; set; } = new ShowcaseModel();
        public IEnumerable<ProductModel> Products { get; set; } = new List<ProductModel>();
    }
}
