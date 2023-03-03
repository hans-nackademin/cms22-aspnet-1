using Microsoft.Extensions.Primitives;

namespace WebApp.Models.ViewModels
{
    public class CardViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string ImageName { get; set; } = null!;
    }
}
