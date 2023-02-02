namespace WebApp.Models.Products
{
    public class ProductModel
    {
        public string ArticleNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Vendor { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Tag { get; set; }
        public int Rating { get; set; }  
        public string ImageUrl { get; set; }
    }
}
