using System.ComponentModel.DataAnnotations;

namespace NGL.Web.Models.ParentCourse
{
    public class GradeModel
    {
        public int StudentUSI { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        [MaxLength(20)]
        public string Grade { get; set; }
    }
} 