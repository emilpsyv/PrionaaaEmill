using System.ComponentModel.DataAnnotations;

namespace ProniaEmil.ViewModels.Sliders
{
    public class GetSliderVM
    {
        
        public int Id { get; set; }

        public string Title { get; set; }

        
        public string SubTitle { get; set; }

        public bool IsDeleted { get; set; }
        public int Discount { get; set; }

        public string ImgUrl { get; set; }
    }
}
