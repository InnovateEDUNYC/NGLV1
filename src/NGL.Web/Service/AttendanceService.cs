using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Repositories;

namespace NGL.Web.Service
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public void RecordAttendanceFor(Section section, DateTime date, IEnumerable<StudentSectionAttendanceEvent> newAttendanceEvents)
        {

            var existingAttendanceEvents = _attendanceRepository.GetSectionAttendanceEventsFor(section, date);

            if (!existingAttendanceEvents.IsNullOrEmpty())
            {
                foreach (var studentSectionAttendanceEvent in existingAttendanceEvents)
                    DecrementFlagCount(studentSectionAttendanceEvent);

                _attendanceRepository.Delete(existingAttendanceEvents);
            }

            foreach (var studentSectionAttendanceEvent in newAttendanceEvents)
            {
                IncrementFlagCount(studentSectionAttendanceEvent);
            }
            _attendanceRepository.AddStudentSectionAttendanceEventList(newAttendanceEvents);
        }

        private void IncrementFlagCount(StudentSectionAttendanceEvent studentSectionAttendanceEvent)
        {
            var attendanceType = studentSectionAttendanceEvent.AttendanceEventCategoryDescriptorId;
            if (attendanceType != (int) AttendanceEventCategoryDescriptorEnum.Tardy &&
                attendanceType != (int) AttendanceEventCategoryDescriptorEnum.UnexcusedAbsence) 
                    return;

            if (studentSectionAttendanceEvent.Student.AttendanceFlags.IsNullOrEmpty())
                CreateNewAttendanceFlagEntryFor(studentSectionAttendanceEvent.Student);
                
            var flagCount = studentSectionAttendanceEvent.Student.AttendanceFlags.First().FlagCount;

            if (flagCount < 10)
                studentSectionAttendanceEvent.Student.AttendanceFlags.First().FlagCount++;
        }

        private void CreateNewAttendanceFlagEntryFor(Student student)
        {
            student.AttendanceFlags = new List<AttendanceFlag>
            {
                new AttendanceFlag
                {
                    FlagCount = 0,
                    StudentUSI = student.StudentUSI
                }
            };
        }

        private static void DecrementFlagCount(StudentSectionAttendanceEvent studentSectionAttendanceEvent)
        {
            var attendanceType = studentSectionAttendanceEvent.AttendanceEventCategoryDescriptorId;
            if (attendanceType == (int) AttendanceEventCategoryDescriptorEnum.Tardy || attendanceType == (int) AttendanceEventCategoryDescriptorEnum.UnexcusedAbsence)
            {
                studentSectionAttendanceEvent.Student.AttendanceFlags.First().FlagCount--;
            }
        }
    }
}
