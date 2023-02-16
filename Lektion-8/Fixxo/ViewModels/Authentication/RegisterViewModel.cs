using Fixxo.Models.Forms;

namespace Fixxo.ViewModels.Authentication
{
    public class RegisterViewModel
    {
        public RegisterForm Form { get; set; } = null!;
        public string ReturnUrl { get; set; } = null!;
    }
}
