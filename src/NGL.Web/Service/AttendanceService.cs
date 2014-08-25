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
                    DecrementFlagCount(studentSectionAttendanceEvent, studentSectionAttendanceEvent.Student);

                _attendanceRepository.Delete(existingAttendanceEvents);
            }

            var studentSectionAttendanceEventList = newAttendanceEvents as IList<StudentSectionAttendanceEvent> ?? newAttendanceEvents.ToList();
            foreach (var studentSectionAttendanceEvent in studentSectionAttendanceEventList)
            {
                IncrementFlagCount(studentSectionAttendanceEvent);
            }
            _attendanceRepository.AddStudentSectionAttendanceEventList(studentSectionAttendanceEventList);
        }

        public void ClearAllFlags()
        {
            var flags = _attendanceRepository.GetAllFlags();
            foreach (var flag in flags)
            {
                flag.FlagCount = 0;
            }
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

        private static void DecrementFlagCount(StudentSectionAttendanceEvent studentSectionAttendanceEvent, Student student)
        {
            var attendanceType = studentSectionAttendanceEvent.AttendanceEventCategoryDescriptorId;
            if (attendanceType != (int) AttendanceEventCategoryDescriptorEnum.Tardy &&
                attendanceType != (int) AttendanceEventCategoryDescriptorEnum.UnexcusedAbsence) 
                    return;

            var flagCount = student.AttendanceFlags.First().FlagCount;

            if (flagCount > 0)
                student.AttendanceFlags.First().FlagCount--;
        }
    }
}
