using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.Entitites
{
    public class ProductEntity
    {
        [Key]
        public string SKU { get; set; } = null!;
        public string Name { get; set; } = null!;

        [Column(TypeName = "money")]
        public decimal Price { get; set; } 
        public string? ImageName { get; set; }
        public string? IngressDescription { get; set; }
        public string? Description { get; set; }
        public string? AdditionalInformation { get; set; }

        public virtual ICollection<TagEntity> Tags { get; set; } = new HashSet<TagEntity>();
        public virtual ICollection<CategoryEntity> Categories { get; set; } = new HashSet<CategoryEntity>();
    }
}
