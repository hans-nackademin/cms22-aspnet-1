using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace _02_ProfileAndImageUpload.Models.Forms
{
    public class SignInForm
    {
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail Address")]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = null!;

        public string ReturnUrl { get; set; } = null!;
    }
}
