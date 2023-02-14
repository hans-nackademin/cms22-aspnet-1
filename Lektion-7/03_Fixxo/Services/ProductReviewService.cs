using _03_Fixxo.Contexts;
using _03_Fixxo.Models;
using _03_Fixxo.Models.Entitites;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _03_Fixxo.Services
{
    public class ProductReviewService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProductReviewService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task AddReviewAsync(ProductReviewModel review)
        {
            _context.Add(_mapper.Map<ProductReviewEntity>(review));
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductReviewModel>> GetReviewsAsync(string productSKU)
        {
            return _mapper.Map<IEnumerable<ProductReviewModel>>(await _context.ProductReviews
                .Where(x => x.ProductSKU == productSKU).ToListAsync());
        }
    }
}
