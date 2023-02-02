using WebApp.Models.Navigation;

namespace WebApp.ViewModels.Navigaton
{
    public class NavLinksViewModel
    {
        public string ClassName { get; set; } = "menu-links";
        public List<NavLinkModel> Links { get; set; } = new List<NavLinkModel>();
    }
}
