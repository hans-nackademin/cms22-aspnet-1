using _03_Fixxo.Contexts;
using _03_Fixxo.Models;
using Microsoft.EntityFrameworkCore;

namespace _03_Fixxo.Services
{
    public class ProductService
    {
        private readonly DataContext _context;
        private readonly ProductReviewService _productReviewService;

        public ProductService(ProductReviewService productReviewService, DataContext context)
        {
            _productReviewService = productReviewService;
            _context = context;
        }

        public async Task<IEnumerable<ProductModel>> GetProducts()
        {
            var _products = await _context.Products
                .Include(x => x.Brand)
                .Include(x => x.Category)
                .Include(x => x.Description)
                .ToListAsync();

            var products = new List<ProductModel>();
            foreach (var product in _products)
            {
                products.Add(new ProductModel
                {
                    Name = product.Name,
                    ShortDescription = product.Description.Short,
                    LongDescription = product.Description.Long,
                    Category = product.Category.Category,
                    Brand = product.Brand.Name,
                    Reviews = await _productReviewService.GetReviewsAsync(product.SKU)
                });
            }

            return products;

        }
    }
}
