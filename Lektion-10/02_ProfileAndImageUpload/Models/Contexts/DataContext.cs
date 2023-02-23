using _02_ProfileAndImageUpload.Models.Entitites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _02_ProfileAndImageUpload.Models.Contexts
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ProfileEntity> UserProfiles { get; set; } = null!;
    }
}
