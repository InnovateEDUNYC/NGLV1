using System.Collections.Generic;
using System.Linq;
using NGL.Tests.Builders;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Attendance;
using Shouldly;
using Xunit;

namespace NGL.Tests.Attendance
{
    public class TakeAttendanceModelToStudentSectionAttendanceEventListMapperTests
    {
        [Fact]
        public void ShouldMap()
        {
            var student = new StudentBuilder().Build();
            var takeAttendanceModel = new TakeAttendanceModelBuilder().WithStudent(student).Build();
            var section = new SectionBuilder().WithStudent(student).Build();

            var mapper = new TakeAttendanceModelToStudentSectionAttendanceEventListMapper();
            var studentSectionAttendanceEventList = mapper.Build(takeAttendanceModel, section).ToList();

            studentSectionAttendanceEventList.First().StudentUSI.ShouldBe(student.StudentUSI);
            studentSectionAttendanceEventList.First().Student.ShouldBe(student);
        }
    }
}
