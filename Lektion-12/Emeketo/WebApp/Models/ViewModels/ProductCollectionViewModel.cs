using WebApp.Models.Entitites;

namespace WebApp.Models.ViewModels
{
    public class ProductCollectionViewModel
    {
        public string Title { get; set; } = null!;
        public IEnumerable<CategoryEntity> Categories { get; set; } = new List<CategoryEntity>();
        public IEnumerable<ProductEntity> Products { get; set; } = new List<ProductEntity>();
    }
}
