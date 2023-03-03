using WebApi.Models.Entitites;

namespace WebApi.Models
{
    public class ProductRequest
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Specification { get; set; }
        public string ProductType { get; set; } = null!;
        public string? ImageName { get; set; }
        public List<string> Tags { get; set; } = new List<string>();

        public static implicit operator ProductEntity(ProductRequest entity)
        {
            return new ProductEntity
            {
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
