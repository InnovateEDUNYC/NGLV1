using System.ComponentModel.DataAnnotations;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Account
{
    public class AddUserModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public ApplicationRole Role { get; set; }

        [Required]
        public int? StaffUSI { get; set; }
        
        [Required]
        [MaxLength(75)]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(75)]
        public string LastName { get; set; }
        
        public bool HispanicLatino { get; set; }
    }
}