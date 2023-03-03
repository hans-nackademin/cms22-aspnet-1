namespace WebApp.Models.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<CardViewModel> BestCollection { get; set;} = new List<CardViewModel>();
        public IEnumerable<CardViewModel> NewProducts { get; set; } = new List<CardViewModel>();
        public IEnumerable<CardViewModel> PopularProducts { get; set; } = new List<CardViewModel>();
    }
}
