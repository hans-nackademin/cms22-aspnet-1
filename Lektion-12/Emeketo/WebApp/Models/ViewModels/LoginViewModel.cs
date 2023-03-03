using WebApp.Models.Forms;

namespace WebApp.Models.ViewModels
{
    public class LoginViewModel
    {
        public string ReturnUrl { get; set; } = null!;
        public LoginForm Form { get; set; } = new LoginForm();
    }
}
