using System.ComponentModel.DataAnnotations;

namespace _01_Identity_Roles_Claims.Models.Forms
{
    public class SignInForm
    {
        [Required]
        [Display(Name = "Your E-Mail Address")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [Display(Name = "Your Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        public string ReturnUrl { get; set; } = null!;
    }
}
