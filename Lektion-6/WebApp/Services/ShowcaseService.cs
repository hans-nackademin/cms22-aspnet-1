using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApp.Contexts;
using WebApp.Models;

namespace WebApp.Services
{
    public class ShowcaseService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ShowcaseService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ShowcaseModel> GetLatestShowcase()
        {
            return _mapper.Map<ShowcaseModel>(
                    await _context.Showcases
                        .Include(x => x.NavLink)
                        .Include(x => x.Image)
                        .OrderByDescending(x => x.Id)
                        .FirstOrDefaultAsync()
                );
        }
    }
}
