using System.Collections.Generic;
using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Attendance;

namespace NGL.Tests.Builders
{
    public class TakeAttendanceModelBuilder
    {
        private string _date = "09/09/2014";
        private readonly int? _sectionId = 7;
        private readonly int? _sessionId = 1;
        private const string _section = "Math 123";
        private const string _session = "Fall 2014";
        private readonly List<StudentAttendanceRowModel> _studentRows = new List<StudentAttendanceRowModel>();

        public TakeAttendanceModel Build()
        {
            var takeAttendanceModel = new TakeAttendanceModel
            {
                Date = _date,
                SectionId = _sectionId,
                Section = _section,
                SessionId = _sessionId,
                Session = _session,
            };

            if (_studentRows.Any())
                takeAttendanceModel.StudentRows = _studentRows;

            return takeAttendanceModel;
        }

        public TakeAttendanceModelBuilder WithDate(string date)
        {
            _date = date;
            return this;
        }

        public TakeAttendanceModelBuilder WithStudent(Web.Data.Entities.Student student)
        {
            _studentRows.Add(new StudentAttendanceRowModel
            {
                AttendanceType = AttendanceEventCategoryDescriptorEnum.InAttendance,
                StudentUsi = student.StudentUSI
            });

            return this;
        }
    }
}
