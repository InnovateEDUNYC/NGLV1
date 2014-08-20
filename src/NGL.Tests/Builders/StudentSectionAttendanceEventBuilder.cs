using NGL.Web.Data.Entities;

namespace NGL.Tests.Builders
{
    public class StudentSectionAttendanceEventBuilder
    {
        private int _attendanceEventCategoryDescriptorId = (int) AttendanceEventCategoryDescriptorEnum.InAttendance;

        public StudentSectionAttendanceEvent Build()
        {
            return new StudentSectionAttendanceEvent { AttendanceEventCategoryDescriptorId = _attendanceEventCategoryDescriptorId};
        }

        public StudentSectionAttendanceEventBuilder WithAttendanceEventCategoryDescriptorId(
            int attendanceEventCategoryDescriptorId)
        {
            _attendanceEventCategoryDescriptorId = attendanceEventCategoryDescriptorId;
            return this;
        }
    }
}