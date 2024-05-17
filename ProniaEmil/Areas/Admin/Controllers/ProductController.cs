using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaEmil.DataAccesLayer;
using ProniaEmil.Extentions;
using ProniaEmil.Models;
using ProniaEmil.ViewModels.Products;
using ProniaEmil.ViewModels.Sliders;
using System.Text;

namespace ProniaEmil.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController(ProniaEContext _context,IWebHostEnvironment _env) : Controller
    {
        public async Task< IActionResult> Index()
        {
            var data = await _context.Products.Where(x => !x.IsDeleted).Select(s => new GetProductAdminVM
            {
                CostPrice = s.CostPrice,
                SellPrice = s.SellPrice,
                Discount = s.Discount,
                Id = s.Id,
                Name = s.Name,
                ImgUrl = s.ImgUrl,
                Raiting= s.Raiting,
                StockCount= s.StockCount,
                CreatedTime= s.CreatedTime
                
                

            }).ToListAsync();
            return View(data);
        }
        [HttpGet]
        public async Task <IActionResult> Create()
        {
            ViewBag.Categories= await _context.Categories.Where(s=>!s.IsDeleted).ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVM data)
        {
            if (!data.ImageFile.IsValidType("image"))
                ModelState.AddModelError("ImageFile", "Fayl sekil olmalidir");
            if (!data.ImageFile.IsValidLength(200))
                ModelState.AddModelError("ImageFile", "Filenin olcusu 200kbdan cox olmamalidir");     
            bool isImageValid =true;
            StringBuilder sb = new StringBuilder();


            foreach (var img in data.ImageFiles)
            {
                sb.Append(img.Name);
                if (!img.IsValidType("image"))
                {
                    
                    sb.Append(img.FileName + "File sekil olmalidir " );
                    isImageValid = false;
                }
                    //ModelState.AddModelError("ImageFile",img.FileName + "Fayl sekil olmalidir");
                if (!img.IsValidLength(400))
                {
                    sb.Append(img.FileName + "Filenin olcusu 400 kbdan cox olmamalidir");
                    isImageValid = false;
                }
                    //ModelState.AddModelError("ImageFile",img.FileName +  "Filenin olcusu 200kbdan cox olmamalidir");

            }
            if (!ModelState.IsValid)   
            {
                return View(data);
            }
            string fileName = await data.ImageFile.SaveFileAsync( Path.Combine(_env.WebRootPath,"imgs", "products"));
         Product product = new Product
         {
             CostPrice = data.CostPrice,
             SellPrice = data.SellPrice,
             Discount = data.Discount,
             ImgUrl = Path.Combine("imgs", "products",fileName),
             IsDeleted = false,
             Name = data.Name,
             Raiting = data.Raiting,
             StockCount = data.StockCount,
             CreatedTime = DateTime.Now,
             Images = new List<ProductImage>(),
             ProductCategories = data.CategoryIDs.Select(x=>new
             ProductCategory
             {
                 Category = x
             }).ToList()

         };
            foreach (var img in data.ImageFiles)
            {
                string ImgName = await img.SaveFileAsync(Path.Combine(_env.WebRootPath, "imgs", "products"));
                product.Images.Add(new ProductImage
                {
                    ImageUrl = Path.Combine("imgs", "products", fileName),
                    IsDeleted = false,
                    CreatedTime= DateTime.Now,
                    
                }
                );
            }

          await _context.Products.AddAsync(product
          );
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
 
        }
    }
}
