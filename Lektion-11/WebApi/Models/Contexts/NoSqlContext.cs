using Microsoft.EntityFrameworkCore;
using WebApi.Models.Entitites;

namespace WebApi.Models.Contexts
{
    public class NoSqlContext : DbContext
    {
        public NoSqlContext(DbContextOptions<NoSqlContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> ProductsCatalog { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>()
                .ToContainer("productCatalog")
                .HasPartitionKey(x => x.Id);
        }
    }
}
