using System;
using System.Collections.Generic;
using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Filters;

namespace NGL.Web.Models.Student
{
    public class StudentAttendancePercentageMapper : MapperBase<IList<Data.Entities.StudentSectionAttendanceEvent>, ProfileModel>
    {
        private readonly ISessionFilter _sessionFilter;

        public StudentAttendancePercentageMapper(ISessionFilter sessionFilter)
        {
            _sessionFilter = sessionFilter;
        }

        public override void Map(IList<Data.Entities.StudentSectionAttendanceEvent> source, ProfileModel target)
        {
            var schoolYear = _sessionFilter.FindSession(DateTime.Now.Date).SchoolYear;
            var attendanceForCurrentSchoolYear = source.Where(ssae => ssae.SchoolYear == schoolYear).ToList();

            var presents = attendanceForCurrentSchoolYear.Count(ae => 
                ae.AttendanceEventCategoryDescriptorId    == (int)AttendanceEventCategoryDescriptorEnum.InAttendance
                || ae.AttendanceEventCategoryDescriptorId == (int)AttendanceEventCategoryDescriptorEnum.Earlydeparture
                || ae.AttendanceEventCategoryDescriptorId == (int)AttendanceEventCategoryDescriptorEnum.ExcusedAbsence);

            target.AttendancePercentage = CalculateAttedancePercentage(presents, attendanceForCurrentSchoolYear);
        }

        private int CalculateAttedancePercentage(int presents, List<Data.Entities.StudentSectionAttendanceEvent> attendanceEvents)
        {
            var count = attendanceEvents.Count;
            if (count < 1)
                return 0;

            return 100 * presents/count;
        }
    }
}