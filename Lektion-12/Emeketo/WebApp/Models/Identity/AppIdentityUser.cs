using Microsoft.AspNetCore.Identity;
using WebApp.Models.Entitites;

namespace WebApp.Models.Identity
{
    public class AppIdentityUser : IdentityUser
    {
        public Guid ProfileId { get; set; }
        public UserProfileEntity Profile { get; set; } = null!;
    }
}
