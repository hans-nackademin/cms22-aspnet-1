namespace WebApi.Models.Entitites
{
    public class ProductEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Specification { get; set; }
        public string ProductType { get; set; } = null!;
        public string PartitionKey { get; set; } = "Product";
        public List<string> Tags { get; set; } = new List<string>();
        public string? ImageName { get; set; }

        public static implicit operator Product(ProductEntity entity)
        {
            return new Product
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                Specification = entity.Specification,
                ProductType = entity.ProductType,
                ImageName = entity.ImageName,
                Tags = entity.Tags,
            };
        }
    }
}
