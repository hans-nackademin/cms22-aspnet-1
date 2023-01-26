using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models.Entities
{
    public class ProductEntity
    {
        [Key]
        public string ArticleNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public int Rating { get; set; }

        public int CategoryId { get; set; }
        public int TagId { get; set; }

        public CategoryEntity Category { get; set; } = null!;
        public TagEntity Tag { get; set; } = null!;
    }
}
