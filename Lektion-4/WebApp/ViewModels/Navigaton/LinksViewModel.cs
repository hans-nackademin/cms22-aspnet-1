using WebApp.Models.Navigation;

namespace WebApp.ViewModels.Navigaton
{
    public class LinksViewModel
    {
        public string ClassName { get; set; } = "link";
        public List<LinkModel> Links { get; set; } = new List<LinkModel>();
    }
}
