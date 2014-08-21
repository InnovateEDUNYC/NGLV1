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

            _mapper.Map(studentSectionAttendanceEvents, _profileModel);
            _profileModel.AttendancePercentage.ShouldBe(80);
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
            _mapper = new StudentAttendancePercentageMapper();
            _profileModel = new ProfileModel();
        }
    }
}
