using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Course;
using NGL.Web.Models.School;
using NGL.Web.Models.Section;
using NGL.Web.Models.Session;

namespace NGL.Web.Models.CourseOffering
{
    public class CourseOfferingModel
    {
        public int TermTypeId { get; set; }
        public short SchoolYear { get; set; }
        public string LocalCourseCode { get; set; }
        public string LocalCourseTitle { get; set; }
        public string CourseCode { get; set; }

        public CourseModel Course { get; set; }
        public SchoolModel School { get; set; }
        public SessionCreateModel Session { get; set; }
        public ICollection<SectionModel> Sections { get; set; }
    }
}