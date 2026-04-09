using E_Commerce_Website.Models.MVVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace E_Commerce_Website.ViewCompenents
{
    public class Contact : ViewComponent
    
    {
        webContext context = new webContext();

        public IViewComponentResult Invoke()
        {
            Setting setting = context.Settings.FirstOrDefault(s => s.SettingID == 1);
            return View(setting);
        }
    }
}
