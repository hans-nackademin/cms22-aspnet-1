using ConsoleApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<TagEntity> Tags { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }  
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\HansMattin-Lassei\\Documents\\Utbildning\\CMS22\\cms22-aspnet-1\\Lektion-1\\ConsoleApp\\Contexts\\local_sql.mdf;Integrated Security=True;Connect Timeout=30");
        }
    }
}
