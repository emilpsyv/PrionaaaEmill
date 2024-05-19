using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ProniaEmil.DataAccesLayer;
using ProniaEmil.ViewModels.Products;

namespace ProniaEmil.ViewComponents
{
    public class ProductViewComponent(ProniaEContext _context) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
          var data= await _context.Products.Select(p=>new GetPtoductVM
            {
                Name = p.Name,
                id = p.Id,
                Discount = p.Discount,
                ImgUrl = p.ImgUrl,
                Raiting = p.Raiting,
                SellPrice = p.SellPrice,
                IsStock=p.StockCount>0
            }).ToListAsync();


            return View(data);
        }
    }
}
