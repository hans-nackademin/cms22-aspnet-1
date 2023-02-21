using _01_Identity_Roles_Claims.Models.Entitites;
using Microsoft.EntityFrameworkCore;

namespace _01_Identity_Roles_Claims.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }
    }
}
