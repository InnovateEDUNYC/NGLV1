using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Section;
using NGL.Web.Models.Student;

namespace NGL.Web.Models.StudentSectionAttendanceEvent
{
    public class StudentSectionAttendanceEventModel
    {
        public int StudentUSI { get; set; }
        public string ClassPeriodName { get; set; }
        public string ClassroomIdentificationCode { get; set; }
        public string LocalCourseCode { get; set; }
        public int TermTypeId { get; set; }
        public short SchoolYear { get; set; }
        public System.DateTime EventDate { get; set; }
        public string AttendanceEventReason { get; set; }

        public virtual AttendanceEventCategoryDescriptor AttendanceEventCategoryDescriptor { get; set; }
        public SectionModel Section { get; set; }
        public StudentModelForStudentSectionAttendanceEvent Student { get; set; }

    }
}