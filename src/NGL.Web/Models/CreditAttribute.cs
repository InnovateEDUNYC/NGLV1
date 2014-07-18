using System.ComponentModel.DataAnnotations;

namespace NGL.Web.Models
{
    public class CreditAttribute : RegularExpressionAttribute
    {
        public CreditAttribute() : base(@"^\d{0,7}.\d{0,2}$")
        {
            ErrorMessage = "Credit must be a number between 0 and 9999999.99";
        }
    }
}