using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_Identity_Roles_Claims.Models.Entitites
{
    public class ProductEntity
    {
        [Key]
        public string ArticleNumber { get; set; } = null!;

        public string Name { get; set; } = null!;

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public string? Category { get; set; } 
        public int Rating { get; set; }
    }
}
