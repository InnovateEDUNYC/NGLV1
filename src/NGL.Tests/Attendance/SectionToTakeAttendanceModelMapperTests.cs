using System;
using System.Linq;
using NGL.Tests.Builders;
using NGL.Web.Data.Entities;
using NGL.Web.Infrastructure.Azure;
using NGL.Web.Models.Attendance;
using NSubstitute;
using Shouldly;
using Xunit;

namespace NGL.Tests.Attendance
{
    public class SectionToTakeAttendanceModelMapperTests
    {
        [Fact]
        public void ShouldMap()
        {
            var student1 = new StudentBuilder().Build();
            var student2 = new StudentBuilder().WithStudentUsi(1234).WithFirstName("Mike").Build();
            var section = new SectionBuilder().WithStudent(student1).WithStudent(student2).Build();

            var date = student1.StudentSectionAssociations.First().BeginDate.AddDays(1);

            var downloader = Substitute.For<IFileDownloader>();
            var profilePhotoUrlFetcher = Substitute.For<ProfilePhotoUrlFetcher>(downloader);

            var takeAttendanceModel = new SectionToTakeAttendanceModelMapper(profilePhotoUrlFetcher).Build(section, date);

            takeAttendanceModel.SectionId.ShouldBe(section.SectionIdentity);
            takeAttendanceModel.Section.ShouldBe(section.UniqueSectionCode + " (" + section.LocalCourseCode + ", " + section.ClassPeriodName + ")");
            takeAttendanceModel.SessionId.ShouldBe(section.Session.SessionIdentity);
            takeAttendanceModel.Session.ShouldBe(section.Session.SessionName);

            takeAttendanceModel.StudentRows.Count.ShouldBe(2);
            takeAttendanceModel.StudentRows[0].StudentUsi.ShouldBe(student1.StudentUSI);
            takeAttendanceModel.StudentRows[0].StudentName.ShouldBe(student1.FirstName + " " + student1.LastSurname);
            takeAttendanceModel.StudentRows[0].AttendanceType.ShouldBe(AttendanceEventCategoryDescriptorEnum.InAttendance);
            takeAttendanceModel.StudentRows[1].StudentUsi.ShouldBe(student2.StudentUSI);
            takeAttendanceModel.StudentRows[1].StudentName.ShouldBe(student2.FirstName + " " + student2.LastSurname);
            takeAttendanceModel.StudentRows[1].AttendanceType.ShouldBe(AttendanceEventCategoryDescriptorEnum.InAttendance);
        }
    }
}
