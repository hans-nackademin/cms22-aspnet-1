using _01_Identity_Roles_Claims.Models.Entitites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _01_Identity_Roles_Claims.Contexts
{
    public class IdentityContext : IdentityDbContext
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }

        public DbSet<UserProfileEntity> UserProfile { get; set; }
    }
}
