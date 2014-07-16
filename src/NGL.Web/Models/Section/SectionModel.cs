using System.Collections.Generic;
using NGL.Web.Models.CourseOffering;
using NGL.Web.Models.School;
using NGL.Web.Models.StudentSectionAttendanceEvent;

namespace NGL.Web.Models.Section
{
    public class SectionModel
    {
        public string ClassPeriodName { get; set; }
        public string ClassroomIdentificationCode { get; set; }
        public string LocalCourseCode { get; set; }
        public int TermTypeId { get; set; }
        public short SchoolYear { get; set; }
        public string UniqueSectionCode { get; set; }
        public int SequenceOfCourse { get; set; }

        public virtual ClassPeriod.CreateModel ClassPeriod { get; set; }
        public virtual CourseOfferingModel CourseOffering { get; set; }
        public virtual Location.CreateModel Location { get; set; }
        public virtual SchoolModel School { get; set; }
        public virtual Session.CreateModel Session { get; set; }
        public virtual ICollection<StudentSectionAttendanceEventModel> StudentSectionAttendanceEvents { get; set; }
    }
}