using NGL.Web.Data.Entities;

namespace NGL.Tests.Builders
{
    public class StudentSectionAttendanceEventBuilder
    {
        private int _attendanceEventCategoryDescriptorId = (int) AttendanceEventCategoryDescriptorEnum.InAttendance;
        private short _schoolYear = (short) SchoolYearTypeEnum.Year2014;
        private Web.Data.Entities.Student _student;
        private Web.Data.Entities.Section _section;

        public StudentSectionAttendanceEvent Build()
        {
            var studentSectionAttendanceEvent = new StudentSectionAttendanceEvent
            {
                AttendanceEventCategoryDescriptorId = _attendanceEventCategoryDescriptorId,
                SchoolYear = _schoolYear
            };

            if (_student != null)
            {
                studentSectionAttendanceEvent.StudentUSI = _student.StudentUSI;
                studentSectionAttendanceEvent.Student = _student;
            }                

            if (_section != null)
            {
                studentSectionAttendanceEvent.SchoolId = _section.SchoolId;
                studentSectionAttendanceEvent.SchoolYear = _section.SchoolYear;
                studentSectionAttendanceEvent.TermTypeId = _section.TermTypeId;
                studentSectionAttendanceEvent.LocalCourseCode = _section.LocalCourseCode;
                studentSectionAttendanceEvent.ClassPeriodName = _section.ClassPeriodName;
                studentSectionAttendanceEvent.ClassroomIdentificationCode = _section.ClassroomIdentificationCode;
            }

            return studentSectionAttendanceEvent;
        }

        public StudentSectionAttendanceEventBuilder WithAttendanceEventCategoryDescriptorId(
            int attendanceEventCategoryDescriptorId)
        {
            _attendanceEventCategoryDescriptorId = attendanceEventCategoryDescriptorId;
            return this;
        }

        public StudentSectionAttendanceEventBuilder WithStudent(Web.Data.Entities.Student student)
        {
            _student = student;
            return this;
        }

        public StudentSectionAttendanceEventBuilder WithSection(Web.Data.Entities.Section section)
        {
            _section = section;
            return this;
        }

        public StudentSectionAttendanceEventBuilder WithSchoolYear(SchoolYearTypeEnum year)
        {
            _schoolYear = (short) year;
            return this;
        }
    }
}