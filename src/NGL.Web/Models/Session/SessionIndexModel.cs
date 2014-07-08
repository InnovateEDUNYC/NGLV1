using System.ComponentModel.DataAnnotations;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Session
{
    public class SessionIndexModel
    {
        public string TermType { get; set; }

        [Display(Name = "School Year")]
        public string SchoolYearType { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        public System.DateTime BeginDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        public System.DateTime EndDate { get; set; }
        public int TotalInstructionalDays { get; set; }
    }
}