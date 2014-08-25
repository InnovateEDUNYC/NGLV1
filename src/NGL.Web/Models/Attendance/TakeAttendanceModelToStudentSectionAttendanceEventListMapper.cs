using System;
using System.Collections.Generic;
using System.Linq;

namespace NGL.Web.Models.Attendance
{
    public class TakeAttendanceModelToStudentSectionAttendanceEventListMapper
    {
        public IEnumerable<Data.Entities.StudentSectionAttendanceEvent> Build(TakeAttendanceModel takeAttendanceModel, Data.Entities.Section section)
        {

            return takeAttendanceModel.StudentRows.Select(sr => new Data.Entities.StudentSectionAttendanceEvent
            {
                StudentUSI = sr.StudentUsi,
                Student = section.StudentSectionAssociations.First(ssa => ssa.StudentUSI == sr.StudentUsi).Student,

                AttendanceEventCategoryDescriptorId = (int) sr.AttendanceType, 
                EventDate = DateTime.Parse(takeAttendanceModel.Date),
                SchoolId = section.SchoolId, 
                ClassPeriodName = section.ClassPeriodName, 
                ClassroomIdentificationCode = section.ClassroomIdentificationCode, 
                LocalCourseCode = section.LocalCourseCode, 
                TermTypeId = section.TermTypeId, 
                SchoolYear = section.SchoolYear
            });
        }
    }
}