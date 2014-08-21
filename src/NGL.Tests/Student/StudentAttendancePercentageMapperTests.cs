using System;
using System.Collections.Generic;
using NGL.Tests.Builders;
using NGL.Tests.Session;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Filters;
using NGL.Web.Models.Student;
using NSubstitute;
using Shouldly;
using Xunit;

namespace NGL.Tests.Student
{
    public class StudentAttendancePercentageMapperTests
    {
        private StudentAttendancePercentageMapper _mapper;
        private ProfileModel _profileModel;

        [Fact]
        public void ShouldMap()
        {
            SetUp();
            var studentSectionAttendanceEvents = new[]
            {
                new StudentSectionAttendanceEventBuilder()
                    .WithAttendanceEventCategoryDescriptorId((int) AttendanceEventCategoryDescriptorEnum.Tardy)
                    .WithSchoolYear(SchoolYearTypeEnum.Year2014).Build(),

                    new StudentSectionAttendanceEventBuilder()
                    .WithAttendanceEventCategoryDescriptorId((int) AttendanceEventCategoryDescriptorEnum.InAttendance)
                    .WithSchoolYear(SchoolYearTypeEnum.Year2014).Build(),
                    
                    new StudentSectionAttendanceEventBuilder()
                    .WithAttendanceEventCategoryDescriptorId((int) AttendanceEventCategoryDescriptorEnum.Earlydeparture)
                    .WithSchoolYear(SchoolYearTypeEnum.Year2014).Build(),
                    
                    new StudentSectionAttendanceEventBuilder()
                    .WithAttendanceEventCategoryDescriptorId((int) AttendanceEventCategoryDescriptorEnum.InAttendance)
                    .WithSchoolYear(SchoolYearTypeEnum.Year2014).Build(),
                    
                    new StudentSectionAttendanceEventBuilder()
                    .WithAttendanceEventCategoryDescriptorId((int) AttendanceEventCategoryDescriptorEnum.ExcusedAbsence)
                    .WithSchoolYear(SchoolYearTypeEnum.Year2014).Build(),
            };

            _mapper.Map(studentSectionAttendanceEvents, _profileModel);
            _profileModel.AttendancePercentage.ShouldBe(80);
        }
        
        [Fact]
        public void ShouldOnlyIncludeAttendanceForCurrentSchoolYear()
        {
            SetUp();
            var studentSectionAttendanceEvents = new[]
            {
                new StudentSectionAttendanceEventBuilder()
                    .WithAttendanceEventCategoryDescriptorId((int) AttendanceEventCategoryDescriptorEnum.Tardy)
                    .WithSchoolYear(SchoolYearTypeEnum.Year2013).Build(),

                    new StudentSectionAttendanceEventBuilder()
                    .WithAttendanceEventCategoryDescriptorId((int) AttendanceEventCategoryDescriptorEnum.InAttendance)
                    .WithSchoolYear(SchoolYearTypeEnum.Year2014).Build(),
            };

            _mapper.Map(studentSectionAttendanceEvents, _profileModel);
            _profileModel.AttendancePercentage.ShouldBe(100);
        }
        
        [Fact]
        public void ShouldMapWhenThereAreNoAttendanceEvents()
        {
            SetUp();

            _mapper.Map(new List<StudentSectionAttendanceEvent>(), _profileModel);
            _profileModel.AttendancePercentage.ShouldBe(0);
        }

        private void SetUp()
        {
            var sessionFilter = Substitute.For<ISessionFilter>();
            sessionFilter.FindSession(Arg.Any<DateTime>()).Returns(new SessionBuilder().WithSchoolYear(SchoolYearTypeEnum.Year2014).Build());
            _mapper = new StudentAttendancePercentageMapper(sessionFilter);
            _profileModel = new ProfileModel();
        }
    }
}
