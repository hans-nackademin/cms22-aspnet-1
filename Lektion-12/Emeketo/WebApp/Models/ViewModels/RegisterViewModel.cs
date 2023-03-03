using WebApp.Models.Forms;

namespace WebApp.Models.ViewModels
{
    public class RegisterViewModel
    {
        public string ReturnUrl { get; set; } = null!;
        public RegisterForm Form { get; set; } = new RegisterForm();
    }
}
