using System.Collections.Generic;
using NGL.Tests.Builders;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Student;
using Shouldly;
using Xunit;

namespace NGL.Tests.Student
{
    public class StudentAttendancePercentageMapperTests
    {
        private StudentAttendancePercentageMapper _mapper;
        private Web.Data.Entities.Student _student;
        private ProfileModel _profileModel;

        [Fact]
        public void ShouldMap()
        {
            SetUp();
            var studentSectionAttendanceEvents = new[]
            {
                new StudentSectionAttendanceEventBuilder().WithAttendanceEventCategoryDescriptorId(
                    (int) AttendanceEventCategoryDescriptorEnum.Tardy).Build(),

                    new StudentSectionAttendanceEventBuilder().WithAttendanceEventCategoryDescriptorId(
                    (int) AttendanceEventCategoryDescriptorEnum.InAttendance).Build(),
                    
                    new StudentSectionAttendanceEventBuilder().WithAttendanceEventCategoryDescriptorId(
                    (int) AttendanceEventCategoryDescriptorEnum.Earlydeparture).Build(),
                    
                    new StudentSectionAttendanceEventBuilder().WithAttendanceEventCategoryDescriptorId(
                    (int) AttendanceEventCategoryDescriptorEnum.InAttendance).Build(),
                    
                    new StudentSectionAttendanceEventBuilder().WithAttendanceEventCategoryDescriptorId(
                    (int) AttendanceEventCategoryDescriptorEnum.ExcusedAbsence).Build(),
            };

            _student = new StudentBuilder().WithStudentSectionAttendanceEvents(studentSectionAttendanceEvents).Build();
            _mapper.Map(studentSectionAttendanceEvents, _profileModel);
            _profileModel.AttedancePercentage.ShouldBe("80.00");
        }
        
        [Fact]
        public void ShouldMapWhenThereAreNoAttendanceEvents()
        {
            SetUp();
            _student = new StudentBuilder().Build();

            _mapper.Map(new List<StudentSectionAttendanceEvent>(), _profileModel);
            _profileModel.AttedancePercentage.ShouldBe("0.00");
        }

        private void SetUp()
        {
            _mapper = new StudentAttendancePercentageMapper();
            _profileModel = new ProfileModel();
        }
    }
}
