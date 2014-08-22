using System;
using System.Collections.Generic;
using System.Linq;
using NGL.Tests.Builders;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Repositories;
using NGL.Web.Service;
using NSubstitute;
using Shouldly;
using Xunit;

namespace NGL.Tests.Attendance
{
    public class AttendanceServiceTests
    {
        private Web.Data.Entities.Student _student;
        private Web.Data.Entities.Section _section;
        private IAttendanceRepository _attendanceRepository;
        private AttendanceService _attendanceService;
        private DateTime _date;
        private List<AttendanceFlag> _attendanceFlags;
        private const int TardyId = (int)AttendanceEventCategoryDescriptorEnum.Tardy;
        private const int PresentId = (int) AttendanceEventCategoryDescriptorEnum.InAttendance;


        [Fact]
        public void ShouldAddFlagsWhenStudentIsTardy()
        {
            Setup();

            var newAttendanceEvents = new List<StudentSectionAttendanceEvent>
            {
                new StudentSectionAttendanceEventBuilder()
                .WithAttendanceEventCategoryDescriptorId(TardyId)
                .WithStudent(_student)
                .WithSection(_section)
                .Build()
            };

            _attendanceService.RecordAttendanceFor(_section, _date, newAttendanceEvents);

            _student.AttendanceFlags.First().FlagCount.ShouldBe(1);
        }

        [Fact]
        public void ShouldRemoveFlagsWhenStudentGoesFromTardyToPresent()
        {
            Setup();
            _student.AttendanceFlags.First().FlagCount = 1;

            var existingAttendanceEvents = new List<StudentSectionAttendanceEvent>
            {
                new StudentSectionAttendanceEventBuilder()
                    .WithAttendanceEventCategoryDescriptorId(TardyId)
                    .WithStudent(_student)
                    .WithSection(_section)
                    .Build()
            };
            _attendanceRepository.GetSectionAttendanceEventsFor(_section, _date).Returns(existingAttendanceEvents);

            var newAttendanceEvents = new List<StudentSectionAttendanceEvent>
            {
                new StudentSectionAttendanceEventBuilder()
                    .WithAttendanceEventCategoryDescriptorId(PresentId)
                    .WithStudent(_student)
                    .WithSection(_section)
                    .Build()
            };

            _attendanceService.RecordAttendanceFor(_section, _date, newAttendanceEvents);

            _student.AttendanceFlags.First().FlagCount.ShouldBe(0);
        }

        [Fact]
        public void ShouldNotChangeFlagsWhenStudentGoesFromTardyToTardy()
        {
            Setup();
            _student.AttendanceFlags.First().FlagCount = 1;

            var existingAttendanceEvents = new List<StudentSectionAttendanceEvent>
            {
                new StudentSectionAttendanceEventBuilder()
                    .WithAttendanceEventCategoryDescriptorId(TardyId)
                    .WithStudent(_student)
                    .WithSection(_section)
                    .Build()
            };
            _attendanceRepository.GetSectionAttendanceEventsFor(_section, _date).Returns(existingAttendanceEvents);

            var newAttendanceEvents = new List<StudentSectionAttendanceEvent>
            {
                new StudentSectionAttendanceEventBuilder()
                    .WithAttendanceEventCategoryDescriptorId(TardyId)
                    .WithStudent(_student)
                    .WithSection(_section)
                    .Build()
            };

            _attendanceService.RecordAttendanceFor(_section, _date, newAttendanceEvents);

            _student.AttendanceFlags.First().FlagCount.ShouldBe(1);
        }

        [Fact]
        public void ShouldNotAddMoreThanTenFlags()
        {
            Setup();
            _student.AttendanceFlags.First().FlagCount = 10;

            var existingAttendanceEvents = new List<StudentSectionAttendanceEvent>
            {
                new StudentSectionAttendanceEventBuilder()
                    .WithAttendanceEventCategoryDescriptorId(PresentId)
                    .WithStudent(_student)
                    .WithSection(_section)
                    .Build()
            };
            _attendanceRepository.GetSectionAttendanceEventsFor(_section, _date).Returns(existingAttendanceEvents);

            var newAttendanceEvents = new List<StudentSectionAttendanceEvent>
            {
                new StudentSectionAttendanceEventBuilder()
                    .WithAttendanceEventCategoryDescriptorId(TardyId)
                    .WithStudent(_student)
                    .WithSection(_section)
                    .Build()
            };

            _attendanceService.RecordAttendanceFor(_section, _date, newAttendanceEvents);

            _student.AttendanceFlags.First().FlagCount.ShouldBe(10);
        }

        [Fact]
        public void ShouldNotSubtractBelowZeroFlags()
        {
            Setup();
            _student.AttendanceFlags.First().FlagCount = 0;

            var existingAttendanceEvents = new List<StudentSectionAttendanceEvent>
            {
                new StudentSectionAttendanceEventBuilder()
                    .WithAttendanceEventCategoryDescriptorId(TardyId)
                    .WithStudent(_student)
                    .WithSection(_section)
                    .Build()
            };
            _attendanceRepository.GetSectionAttendanceEventsFor(_section, _date).Returns(existingAttendanceEvents);

            var newAttendanceEvents = new List<StudentSectionAttendanceEvent>
            {
                new StudentSectionAttendanceEventBuilder()
                    .WithAttendanceEventCategoryDescriptorId(PresentId)
                    .WithStudent(_student)
                    .WithSection(_section)
                    .Build()
            };

            _attendanceService.RecordAttendanceFor(_section, _date, newAttendanceEvents);

            _student.AttendanceFlags.First().FlagCount.ShouldBe(0);
        }

        [Fact]
        public void ShouldWipeAllFlags()
        {
            Setup();
            _attendanceRepository.GetAllFlags().Returns(_attendanceFlags);

            _attendanceService.ClearAllFlags();

            foreach (var attendanceFlag in _attendanceFlags)
            {
                attendanceFlag.FlagCount.ShouldBe(0);
            }
        }

        private void Setup()
        {
            _attendanceRepository = Substitute.For<IAttendanceRepository>();
            _attendanceService = new AttendanceService(_attendanceRepository);

            _student = new StudentBuilder().Build();
            _section = new SectionBuilder().WithStudent(_student).Build();
            _date = _student.StudentSectionAssociations.First().BeginDate.AddDays(3);

            _attendanceFlags = new List<AttendanceFlag>
            {
                new AttendanceFlag{StudentUSI = new StudentBuilder().WithStudentUsi(1).Build().StudentUSI, FlagCount = 7},
                new AttendanceFlag{StudentUSI = new StudentBuilder().WithStudentUsi(2).Build().StudentUSI, FlagCount = 6},
                new AttendanceFlag{StudentUSI = new StudentBuilder().WithStudentUsi(3).Build().StudentUSI, FlagCount = 3}
            };
        }
    }
}
