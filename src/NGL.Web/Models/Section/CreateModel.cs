using System.ComponentModel.DataAnnotations;

namespace NGL.Web.Models.Section
{
    public class CreateModel
    {
        [Required]
        public short SchoolYear { get; set; }

        [Required]
        public int TermTypeId { get; set; }

        [Required]
        public string ClassPeriodName { get; set; }

        [Required]
        public string ClassroomIdentificationCode { get; set; }

        [Required]
        [StringLength(20)]
        public string LocalCourseCode { get; set; }

        [Required]
        [StringLength(255)]
        public string UniqueSectionCode { get; set; }

        [Required]
        public int SequenceOfCourse { get; set; }

    }
}