using _02_ProfileAndImageUpload.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace _02_ProfileAndImageUpload.Models.ViewModels.Account
{
    public class IndexViewModel
    {
        public Profile Profile { get; set; } = null!;
    }
}
