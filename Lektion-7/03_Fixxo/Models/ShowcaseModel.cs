using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _03_Fixxo.Models
{
    public class ShowcaseModel
    {
        public string Title_1 { get; set; } = "";
        public string Title_2 { get; set; } = "";
        public string Title_3 { get; set; } = "";
        public NavLinkModel NavLink { get; set; } = new NavLinkModel();
        public ImageModel Image { get; set; } = new ImageModel();
    }
}
