using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace _02_ProfileAndImageUpload.Models.Forms
{
    public class SignUpForm
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail Address")]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = null!;

        public IFormFile? ProfileImage { get; set; }

        public string ReturnUrl { get; set; } = null!;
    }
}
