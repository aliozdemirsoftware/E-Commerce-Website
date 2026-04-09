using E_Commerce_Website.Models.MVVM;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Website.ViewCompenents
{
    public class Headers : ViewComponent
    {
        webContext context = new webContext();

        public IViewComponentResult Invoke()
        {
            List<Category> categories = context.Categories.Where(c => c.Active == true).ToList();
            return View(categories);
        }
    }
}
