using E_Commerce_Website.Models.MVVM;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Website.Models.Concrete
{
    public class SupplierRepository
    {
        webContext context = new webContext();

        public List<Supplier> Get()
        {
            List<Supplier>? suppliers = context.Suppliers?.ToList();
            return suppliers;
        }

        public bool Add(Supplier supplier)
        {
            try
            {
                context.Suppliers?.Add(supplier);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Supplier Get(int? id)
        {
            Supplier? supplier = context.Suppliers?.FirstOrDefault(s => s.SupplierID == id);
            return supplier;
        }

        public bool Update(Supplier supplier)
        {
            try
            {
                context.Suppliers?.Update(supplier);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                Supplier? supplier = context.Suppliers?.FirstOrDefault(s => s.SupplierID == id);
                supplier.Active = false;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Supplier> Details(int id)
        {
            return await context.Suppliers.FirstOrDefaultAsync(s => s.SupplierID == id);
        }
    }
}
