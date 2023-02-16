using System.ComponentModel.DataAnnotations;

namespace Fixxo.Models.Forms
{
    public class LoginForm
    {
        [Required]
        [Display(Name = "E-Mail Address")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Remember me!")]
        public bool RememberMe { get; set; } = false;

        public string ReturnUrl { get; set; } = "/";
    }
}
