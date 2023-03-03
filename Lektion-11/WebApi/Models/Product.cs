namespace WebApi.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Specification { get; set; }
        public string ProductType { get; set; } = null!;
        public string? ImageName { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
    }
}
