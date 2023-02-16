using System.ComponentModel.DataAnnotations;

namespace Fixxo.Models.Forms
{
    public class RegisterForm
    {
        [Required]
        [Display(Name = "Your First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Your Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [Display(Name = "Your E-mail Address")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Your Password")]
        public string Password { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = string.Empty;


        [Display(Name = "Your Street Name (optional)")]
        public string? StreetName { get; set; }

        [Display(Name = "Your Postal Code (optional)")]
        public string? PostalCode { get; set; }

        [Display(Name = "Your City (optional)")]
        public string? City { get; set; }


        public string ReturnUrl { get; set; } = "/";
    }
}
