using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace _02_Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [ProtectedPersonalData]
        [Display(Name = "First name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [ProtectedPersonalData]
        [Display(Name = "Last name")]
        public string LastName { get; set; } = string.Empty;
    }
}
