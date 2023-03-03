namespace WebApp.Models.Identity
{
    public class AppIdentityUserWithRole : AppIdentityUser
    {
        public string RoleName { get; set; } = null!;
    }
}
