﻿using Microsoft.AspNetCore.Mvc;

namespace ProniaEmil.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
