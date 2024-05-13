using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaEmil.DataAccesLayer;
using ProniaEmil.Models;
using ProniaEmil.ViewModels.Sliders;

namespace ProniaEmil.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController(ProniaEContext _context) : Controller
    {
        public async Task< IActionResult> Index()
        {
            var data = await _context.Sliders.Where(x=>!x.IsDeleted).Select(s => new GetSliderVM
            {
                Discount = s.Discount,
                Id = s.Id,
                ImgUrl = s.ImgUrl,
              
                SubTitle = s.SubTitle,
                Title = s.Title
            }).ToListAsync();
            return View(data);
        }
        [HttpGet]
        public async Task< IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateSliderVM vm )

        {
            if (!ModelState.IsValid)
            {
                return View(vm);  
            }
            Slider slider = new Slider
            {
                Discount = vm.Discount,
                CreatedTime = DateTime.Now,
                ImgUrl = vm.ImgUrl,
                IsDeleted = false,
                SubTitle = vm.SubTitle,
                Title = vm.Title
            };
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if(id == null||id<1) { return BadRequest(); }
            Slider slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            if (slider is null) return NotFound();

            UpdateSliderVM sliderVM = new UpdateSliderVM
            {
                Discount = slider.Discount,
                SubTitle = slider.SubTitle,
                Title = slider.Title,
                ImgUrl = slider.ImgUrl,

            };

            return View(sliderVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateSliderVM sliderVM, int? id)
        {
            if (id == null || id < 1) { return BadRequest(); }
            Slider existed = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            if (existed is null) return NotFound();
            existed.Title = sliderVM.Title;
            existed.Discount = sliderVM.Discount;
            existed.SubTitle = sliderVM.SubTitle;
            existed.ImgUrl = sliderVM.ImgUrl;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> DeleteSlider(int? id)
        {
            if (id == null || id < 1) return BadRequest();
            var delS = await _context.Sliders.FindAsync(id);
            if (delS == null) return BadRequest();
            _context.Sliders.Remove(delS);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
