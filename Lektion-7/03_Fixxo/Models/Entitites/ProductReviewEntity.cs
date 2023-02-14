namespace _03_Fixxo.Models.Entitites
{
    public class ProductReviewEntity
    {
        public int Id { get; set; }
        public string ProductSKU { get; set; } = string.Empty;
        public string? Comment { get; set; }
        public int Rating { get; set; }

        public ProductEntity Product { get; set; } = null!;
    }
}
