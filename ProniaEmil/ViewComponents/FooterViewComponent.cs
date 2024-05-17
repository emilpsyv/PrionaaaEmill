using Microsoft.AspNetCore.Mvc;

namespace ProniaEmil.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
      
            public async Task<IViewComponentResult> InvokeAsync()
            {
                return View();
            }
        
    }

}

