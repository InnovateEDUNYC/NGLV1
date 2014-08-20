using System;
using System.Collections.Generic;
using System.Linq;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Student
{
    public class StudentAttendancePercentageMapper : MapperBase<IList<Data.Entities.StudentSectionAttendanceEvent>, ProfileModel>
    {
        public override void Map(IList<Data.Entities.StudentSectionAttendanceEvent> source, ProfileModel target)
        {
            var attendanceEvents = source.ToList();

            var presents = attendanceEvents.Count(ae => 
                ae.AttendanceEventCategoryDescriptorId    == (int)AttendanceEventCategoryDescriptorEnum.InAttendance
                || ae.AttendanceEventCategoryDescriptorId == (int)AttendanceEventCategoryDescriptorEnum.Earlydeparture
                || ae.AttendanceEventCategoryDescriptorId == (int)AttendanceEventCategoryDescriptorEnum.ExcusedAbsence);

            var attedancePercentage = CalculateAttedancePercentage(presents, attendanceEvents);

            target.AttedancePercentage = attedancePercentage.ToString("F");
        }

        private decimal CalculateAttedancePercentage(int presents, List<Data.Entities.StudentSectionAttendanceEvent> attendanceEvents)
        {
            var count = attendanceEvents.Count;
            if (count < 1)
                return 0;
            var attedancePercentage = 100m*Convert.ToDecimal(presents)/Convert.ToDecimal(count);
            return attedancePercentage;
        }
    }
}