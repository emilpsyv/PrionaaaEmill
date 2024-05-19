namespace ProniaEmil.ViewModels.Products
{
    public class GetPtoductVM
    {
        public int id { get; set; }
        public string Name { get; set; }
        public decimal SellPrice { get; set; }
        public int Discount { get; set; }
        public bool IsStock { get; set; }
        public string ImgUrl { get; set; }

        public string ProductCAT { get; set; }
        public float Raiting { get; set; }

    }
}
