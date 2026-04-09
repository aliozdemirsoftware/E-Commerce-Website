using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
namespace E_Commerce_Website.Models.Concrete
{
    public class Connection
    {
        public static SqlConnection ServerConnect

        {

            //TrustServerCertificate=True;
            get
            {
                SqlConnection sqlcon = new SqlConnection("Server=DESKTOP-N7OIBIA\\SQLEXPRESS;Database=TrialWeb_ProjectDB;Trusted_Connection=True;TrustServerCertificate=True;");


                return sqlcon;

            }

        }

    }
}

