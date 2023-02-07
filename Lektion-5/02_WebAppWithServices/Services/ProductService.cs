using _02_WebAppWithServices.Contexts;
using _02_WebAppWithServices.Models;

namespace _02_WebAppWithServices.Services
{
    public class ProductService
    {
        private readonly DataContext _context;
        private List<Product> products;


        public ProductService(DataContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts()
        {
            products = _context.Products.ToList();
            return products;
        }



    }
}
