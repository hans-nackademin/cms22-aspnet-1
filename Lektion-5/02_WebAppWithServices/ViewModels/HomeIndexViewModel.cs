using _02_WebAppWithServices.Models.Partials;

namespace _02_WebAppWithServices.ViewModels
{
    public class HomeIndexViewModel : BaseViewModel
    {
        public HomeIndexViewModel()
        {
            SetShowcase();
        }

        public ShowcaseModel Showcase { get; set; } = null!;
        
        
        
        
        private void SetShowcase()
        {
            Showcase = new ShowcaseModel
            {
                Title_1 = "Don't Miss This Opportunity",
                Title_2 = "GET UP TO 40% OFF",
                Title_3 = "Online shopping free home delivery over $100",
                ButtonText = "SHOP NOW",
                ImageUrl = "~/images/showcase-img.png"
            };
        }
    }
}
