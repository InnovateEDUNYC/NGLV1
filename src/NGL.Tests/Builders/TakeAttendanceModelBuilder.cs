using System;
using System.Collections.Generic;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Attendance;

namespace NGL.Tests.Builders
{
    public class TakeAttendanceModelBuilder
    {
        private DateTime _date = new DateTime(2014, 9, 9);
        private int? _sectionId = 7;
        private int? _sessionId = 1;
        private string _section = "Math 123";
        private string _session = "Fall 2014";
        private IList<StudentAttendanceRowModel> _studentRows = null;

        public TakeAttendanceModel Build()
        {
            return new TakeAttendanceModel
            {
                Date = _date,
                SectionId = _sectionId,
                Section = _section,
                SessionId = _sessionId,
                Session = _session,
                StudentRows = _studentRows
            };
        }

        public TakeAttendanceModelBuilder WithStudentRows(int numberOfRows)
        {
            _studentRows = new List<StudentAttendanceRowModel>();
            for (int i = 0; i < numberOfRows; i++)
            {
                _studentRows.Add(new StudentAttendanceRowModel
                {
                    AttendanceType = AttendanceEventCategoryDescriptorEnum.Tardy
                });
            }

            return this;
        }
    }
}
