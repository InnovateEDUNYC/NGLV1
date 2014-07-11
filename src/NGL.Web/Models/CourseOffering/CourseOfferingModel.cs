using System.Collections.Generic;
using NGL.Web.Models.Course;
using NGL.Web.Models.School;
using NGL.Web.Models.Section;
using NGL.Web.Models.Session;
using CreateModel = NGL.Web.Models.Course.CreateModel;

namespace NGL.Web.Models.CourseOffering
{
    public class CourseOfferingModel
    {
        public int TermTypeId { get; set; }
        public short SchoolYear { get; set; }
        public string LocalCourseCode { get; set; }
        public string LocalCourseTitle { get; set; }
        public string CourseCode { get; set; }

        public CreateModel Course { get; set; }
        public SchoolModel School { get; set; }
        public Session.CreateModel Session { get; set; }
        public ICollection<SectionModel> Sections { get; set; }
    }
}