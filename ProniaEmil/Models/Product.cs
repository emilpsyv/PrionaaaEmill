using System.ComponentModel.DataAnnotations;

namespace ProniaEmil.Models
{
    public class Product : BaseEntity
    {
        [MaxLength(32), Required]
        public string Name { get; set; }
        [Range(0, 99999), Required]
        public decimal CostPrice { get; set; }
        [Range(0, 99999), Required]
        public decimal SellPrice { get; set; }
        [Range(0, 100), Required]
        public int Discount { get; set; }
        [Required]
        public int StockCount { get; set; }
        [Required]
        public string ImgUrl { get; set; }

        [Required]
        public float Raiting { get; set; }
        public ICollection<ProductImage>? Images { get; set;}

        public ICollection<ProductCategory>? ProductCategories { get;}
        
    }
}
