using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entitites;
using WebApp.Models.Identity;

namespace WebApp.Models.Contexts
{
    public class DataContext : IdentityDbContext<AppIdentityUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<UserProfileEntity> UserProfiles { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ShowcaseEntity> Showcases { get; set; }
        public DbSet<TagEntity> Tags { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
    }
}
