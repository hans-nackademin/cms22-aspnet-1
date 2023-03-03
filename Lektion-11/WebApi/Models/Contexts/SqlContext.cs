using Microsoft.EntityFrameworkCore;
using WebApi.Models.Entitites;

namespace WebApi.Models.Contexts
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; } 
        public DbSet<UserProfileEntity> Profiles { get; set; }
    }
}
