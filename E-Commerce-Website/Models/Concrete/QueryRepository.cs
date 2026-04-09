using E_Commerce_Website.Models.MVVM;

namespace E_Commerce_Website.Models.Concrete
{
    public class QueryRepository
    {
        webContext context = new webContext();

        public void Queries()
        {
            // sadece bir kayıt, bütün kolonlarının bilgisi
            Product? product = context.Products?.FirstOrDefault(p => p.ProductID == 4);

            // select * from Products
            List<Product>? products = context.Products?.ToList();

            string? productName = context.Products?.FirstOrDefault(p => p.ProductID == 4).ProductName;
            decimal? unitprice = context.Products?.FirstOrDefault(p => p.ProductID == 4).UnitPrice;
        }
    }
}
