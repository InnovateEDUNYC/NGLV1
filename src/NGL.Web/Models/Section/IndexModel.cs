using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Section
{
    public class IndexModel
    {
        public string SchoolYear { get; set; }
        public string Term { get; set; }
        public string ClassPeriod { get; set; }
        public string Classroom { get; set; }
        public string LocalCourseCode { get; set; }
        public string UniqueSectionCode { get; set; }
        public int SequenceOfCourse { get; set; }
    }
}