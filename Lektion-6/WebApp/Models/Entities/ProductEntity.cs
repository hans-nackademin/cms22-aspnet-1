using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Entities
{
    public class ProductEntity
    {
        [Key]
        public string SKU { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int BrandId { get; set; } 
        public int CategoryId { get; set; }
        public int DescriptionId { get; set; }

        public BrandEntity Brand { get; set; } = null!;
        public ProductCategoryEntity Category { get; set; } = null!;
        public ProductDescriptionEntity Description { get; set; } = null!;

    }
}
