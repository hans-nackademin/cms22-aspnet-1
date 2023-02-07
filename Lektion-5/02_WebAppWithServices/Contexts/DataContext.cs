using _02_WebAppWithServices.Models;
using Microsoft.EntityFrameworkCore;

namespace _02_WebAppWithServices.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } 
    }
}
