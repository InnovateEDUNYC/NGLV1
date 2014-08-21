using NGL.Web.Data.Entities;

namespace NGL.Tests.Builders
{
    public class StudentSectionAttendanceEventBuilder
    {
        private int _attendanceEventCategoryDescriptorId = (int) AttendanceEventCategoryDescriptorEnum.InAttendance;
        private short _schoolYear = (short) SchoolYearTypeEnum.Year2022;

        public StudentSectionAttendanceEvent Build()
        {
            return new StudentSectionAttendanceEvent
            {
                AttendanceEventCategoryDescriptorId = _attendanceEventCategoryDescriptorId,
                SchoolYear = _schoolYear,
            };
        }

        public StudentSectionAttendanceEventBuilder WithAttendanceEventCategoryDescriptorId(
            int attendanceEventCategoryDescriptorId)
        {
            _attendanceEventCategoryDescriptorId = attendanceEventCategoryDescriptorId;
            return this;
        }

        public StudentSectionAttendanceEventBuilder WithSchoolYear(SchoolYearTypeEnum schoolYearTypeEnum)
        {
            _schoolYear = (short) schoolYearTypeEnum;
            return this;
        }
    }
}