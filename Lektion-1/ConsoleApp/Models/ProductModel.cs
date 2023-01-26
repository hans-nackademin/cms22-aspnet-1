namespace ConsoleApp.Models
{
    public class ProductModel
    {
        public string ArticleNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Tag { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public int Rating { get; set; }
    }
}
