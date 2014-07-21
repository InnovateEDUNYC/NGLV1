using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ChameleonForms.Attributes;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NGL.Web.Models.Account
{
    public class AddUserModel
    {
        public AddUserModel()
        {
            Roles = new List<IdentityRole>();
        }

        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [ExistsIn("Roles", "Name", "Name", enableValidation: false)]
        public string Role { get; set; }

        public IList<IdentityRole> Roles { get; set; }
    }
}