using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaEmil.DataAccesLayer;
using ProniaEmil.Models;
using ProniaEmil.ViewModels.Categories;
using ProniaEmil.ViewModels.Home;
using ProniaEmil.ViewModels.Sliders;

namespace ProniaEmil.Controllers
{
    public class HomeController(ProniaEContext _context) : Controller
    {

      
        public async Task <IActionResult> Index()
        {
            List<Slider> sliders = await _context.Sliders.ToListAsync();
            List<Category> categories = await _context.Categories.ToListAsync();
            

            HomeVM homeVM = new HomeVM
            {
                Sliders = sliders,
                Categories = categories
            };
            //var data = await _context.Sliders.Where(x => !x.IsDeleted).Select(s => new GetSliderVM
            //{
            //    Discount = s.Discount,
            //    Id = s.Id,
            //    ImgUrl = s.ImgUrl,

            //    SubTitle = s.SubTitle,
            //    Title = s.Title
            //}).ToListAsync();



            return View(homeVM);
        }
        public async Task<IActionResult> DeleteTest(int ? id)
        {
            if (id == null||id<1) return BadRequest();
            var categor = await _context.Categories.FindAsync(id);
            if (categor == null) return BadRequest();
            _context.Categories.Remove(categor);
            await _context.SaveChangesAsync();
            return Content(categor.Name);
        }
        public async Task<IActionResult> Shop()
        {
            return View();
        }
        public async Task<IActionResult> Blog()
        {
            return View();
        }
        public async Task<IActionResult> AboutUs()
        {
            return View();
        }
        public async Task<IActionResult> Pages()
        {
            return View();
        }
        public async Task<IActionResult> ContactUs()
        {
            return View();
        }
    }
}
