using Microsoft.AspNet.Identity.EntityFramework;

namespace NGL.Web.Data.Entities
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class
    // please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public int StaffUSI { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            :base(ConfigManager.ConnectionString)
        {
        }
    }
}