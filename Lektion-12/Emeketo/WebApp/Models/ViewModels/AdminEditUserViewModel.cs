using WebApp.Models.Identity;

namespace WebApp.Models.ViewModels
{
    public class AdminEditUserViewModel
    {
        public AppIdentityUserWithRole User { get; set; } = null!;
        public string CurrentRoleName { get; set; } = null!;
        public string UserId { get; set; } = null!;
    }
}
