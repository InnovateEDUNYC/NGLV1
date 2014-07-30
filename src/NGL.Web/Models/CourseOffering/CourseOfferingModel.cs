using System.Collections.Generic;
using NGL.Web.Models.School;

namespace NGL.Web.Models.CourseOffering
{
    public class CourseOfferingModel
    {
        public int TermTypeId { get; set; }
        public short SchoolYear { get; set; }
        public string LocalCourseCode { get; set; }
        public string LocalCourseTitle { get; set; }
        public string CourseCode { get; set; }

        public Course.CreateModel Course { get; set; }
        public SchoolModel School { get; set; }
        public Session.CreateModel Session { get; set; }
        public ICollection<Section.CreateModel> Sections { get; set; }
    }
}