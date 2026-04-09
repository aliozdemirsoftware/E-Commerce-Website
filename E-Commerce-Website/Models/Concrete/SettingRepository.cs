using E_Commerce_Website.Models.MVVM;

namespace iakademi46CORE_Proje.Models.Concrete
{
    public class SettingRepository
    {
        webContext context = new webContext();
        public Setting? Get()
        {
            return context.Settings?.FirstOrDefault();
        }
        public bool Update(Setting setting)
        {
            try
            {
                context.Settings?.Update(setting);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}