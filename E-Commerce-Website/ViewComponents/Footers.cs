using E_Commerce_Website.Models.MVVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace E_Commerce_Website.ViewCompenents
{
    public class Footers : ViewComponent
    {
        webContext context = new webContext();

        public IViewComponentResult Invoke()
        {
            List<Supplier> suppliers = context.Suppliers.Where(c => c.Active == true).ToList();
            return View(suppliers);
        }


    }
}
