using System.ComponentModel.DataAnnotations;

namespace _03_Fixxo.Models.Forms
{
    public class LoginFormModel
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
