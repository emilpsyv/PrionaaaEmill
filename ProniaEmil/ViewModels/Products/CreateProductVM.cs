using System.ComponentModel.DataAnnotations;

namespace ProniaEmil.ViewModels.Products
{
    public class CreateProductVM
    {
        [MaxLength(32,ErrorMessage ="uzunlug 32 simvoldan cox olmamalidir"), Required]
        public string Name { get; set; }
        [Range(0, 99999,ErrorMessage ="sevh giymet"), Required]
        public decimal CostPrice { get; set; }
        [Range(0, 99999,ErrorMessage ="sevh qiymet"), Required]
        public decimal SellPrice { get; set; }
        [Range(0, 100,ErrorMessage ="endirim 0,100 arasinda olmalidir"), Required]
        public int Discount { get; set; }
        [Required]
        public int StockCount { get; set; }

        public int[] CategoryIDs { get; set; }
        [Required]
        public IFormFile ImageFile { get; set; }

        [Required]
        public IEnumerable<IFormFile> ImageFiles { get; set; }
        [Required]
        public float Raiting { get; set; }
    }
}
