using E_Commerce_Website.Models.MVVM;
using Microsoft.AspNetCore.Mvc;


namespace E_Commerce_Website.ViewCompenents
{
    public class Address : ViewComponent
    {
        webContext context = new webContext();

        public string Invoke()
        {
            string? address = context.Settings.FirstOrDefault(s => s.SettingID == 1)?.Address;
            return $"{address}";
        }
    }
}
