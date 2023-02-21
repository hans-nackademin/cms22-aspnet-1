using System.ComponentModel.DataAnnotations;

namespace _01_Identity_Roles_Claims.Models.Forms
{
    public class SignUpForm
    {
        [Required]
        [Display(Name = "Your First Name")]
        public string FirstName { get; set; } = null!;
        
        [Required]
        [Display(Name = "Your Last Name")]
        public string LastName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [Display(Name = "Your E-mail Address")]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Your Password")]
        public string Password { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;

        public string? StreetName { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }

        public string ReturnUrl { get; set; } = null!;
    }
}
