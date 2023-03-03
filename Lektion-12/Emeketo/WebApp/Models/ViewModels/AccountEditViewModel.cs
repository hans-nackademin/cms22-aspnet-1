using WebApp.Models.Forms;

namespace WebApp.Models.ViewModels
{
    public class AccountEditViewModel
    {
        public string UserId { get; set; } = null!;
        public ProfileEditForm Form { get; set; } = new ProfileEditForm();
    }
}
