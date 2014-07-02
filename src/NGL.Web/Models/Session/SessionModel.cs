using System.ComponentModel.DataAnnotations;

namespace NGL.Web.Models.Session
{
    public class SessionModel
    {
        public int SchoolId { get; set; }
        public int TermTypeId { get; set; }
        public short SchoolYear { get; set; }
        [StringLength(60)]
        public string SessionName { get; set; }
        public System.DateTime BeginDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public int TotalInstructionalDays { get; set; }
    }
}