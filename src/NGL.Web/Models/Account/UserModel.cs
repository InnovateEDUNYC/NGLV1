using System.ComponentModel.DataAnnotations;

namespace NGL.Web.Models.Account
{
    public class UserModel
    {
        [Display(Name = "Staff USI")]
        public int StaffUSI { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Display(Name = "Hispanic/Latino")]
        public bool HispanicLatino { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
    }
}