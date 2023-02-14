using _03_Fixxo.Models;
using _03_Fixxo.Models.Entitites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _03_Fixxo.Contexts
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<NavLinkEntity> NavLinks { get; set; } = null!;
        public DbSet<ImageEntity> Images { get; set; }
        public DbSet<ShowcaseEntity> Showcases { get; set; }
        public DbSet<ProductDescriptionEntity> ProductDescriptions { get; set; }
        public DbSet<ProductCategoryEntity> ProductCategories { get; set; }
        public DbSet<BrandEntity> Brands { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ProductReviewEntity> ProductReviews { get; set; }
    }
}
