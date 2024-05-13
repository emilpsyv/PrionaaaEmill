using System.ComponentModel.DataAnnotations;

namespace ProniaEmil.ViewModels.Sliders
{
    public class UpdateSliderVM
    {
        [MaxLength(32), Required]
        public string Title { get; set; }

        [MaxLength(64), Required]
        public string SubTitle { get; set; }

        [Range(0, 100)]
        public int Discount { get; set; }

        [Required]
        public string ImgUrl { get; set; }
    }
}
