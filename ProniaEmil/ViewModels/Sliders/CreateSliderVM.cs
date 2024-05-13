using System.ComponentModel.DataAnnotations;

namespace ProniaEmil.ViewModels.Sliders
{
    public class CreateSliderVM
    {
        [MaxLength(32, ErrorMessage = "Basliq 32 simvoldan boyuk ola bilmez"), Required]
        public string Title { get; set; }

        [MaxLength(64, ErrorMessage = "Basliq 32 simvoldan boyuk ola bilmez"), Required]
        public string SubTitle { get; set; }

        [Range(0, 100, ErrorMessage = "endirim 100den az 0 dan cox olmalidir")]
        public int Discount { get; set; }

        [Required]
        public string ImgUrl { get; set; }
    }
}
