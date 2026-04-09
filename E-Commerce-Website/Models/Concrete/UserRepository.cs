using E_Commerce_Website.Models.MVVM;

namespace E_Commerce_Website.Models.Concrete
{
    public class UserRepository
    {
        webContext context = new webContext();


        public bool LoginControl(string Email)
        {
            // ORM = ado.net (select,insert,update,delete)
            // select * from Users where Email = 'sedat@hotmail.com'

            // ORM = entityframeworkcore
            // =>  lamdda expression
            User? result = context.Users.FirstOrDefault(u => u.Email == Email);
            if (result == null) return false;
            return true;
        }

        public bool Add(User user)
        {
            try
            {
                user.Active = true;
                context.Users?.Add(user);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string LoginControl(User user)
        {
            // context.Users üzerinden veritabanındaki her bir kullanıcı kaydını geçici olarak u adıyla ele alır
            //bu kayıtların email ve şifre alanlarını, formdan gelen user nesnesindeki bilgilerle karşılaştırır
            //Eşleşme bulunursa, bu kayıt usr adlı değişkene atanır
            User? usr = context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);

            if (usr == null)
            {
                //login/şifre yanlış
                return "error";
            }
            else
            {
                //login/şifre doğru
                if (usr.IsAdmin)
                {
                    return usr.NameSurname!;
                }
                else
                {
                    return usr.Email!;
                }
            }
        }

        public static User Get(string Email)
        {
            webContext context = new webContext();
            User? user = context.Users?.FirstOrDefault(c => c.Email == Email);
            return user;

        }
    }
}
