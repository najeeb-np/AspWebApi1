using AspWebApi1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace AspWebApi1
{
    public class ApiSecurity
    {
        public static bool Login(string userName, string pass)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if(UserManager.FindAsync(userName, pass) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
                          
        }
    }
}