using WebApp.Models.Identity;

namespace WebApp.Models.ViewModels
{
    public class AdminUserManagementViewModel
    {
        public ICollection<AppIdentityUserWithRole> Users { get; set; } = new List<AppIdentityUserWithRole>();
    }
}
