using System;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Repositories;
using NGL.Web.Models.Session;
using NSubstitute;
using Shouldly;
using Xunit;

namespace NGL.Tests.Session
{
    public class SessionMapperTests
    {
        [Fact]
        public void ShouldMapSessionFormViewModelToSessionEntity()
        {
            var schoolRepository = Substitute.For<ISchoolRepository>();
            schoolRepository.GetSchool().Returns(new School{SchoolId = 1});

            var sessionEntity = new Web.Data.Entities.Session();
            var sessionModel = new SessionCreateModel
            {
                TermType = TermTypeEnum.FallSemester,
                SchoolYearType = SchoolYearTypeEnum.Year2014,
                BeginDate = new DateTime(2014, 6, 26),
                EndDate = new DateTime(2014, 9, 26),
                TotalInstructionalDays = 92
            };

            var sessionModelToSessionMapper = new SessionCreateModelToSessionMapper(schoolRepository);
            sessionModelToSessionMapper.Map(sessionModel, sessionEntity);

            sessionEntity.SchoolId.ShouldBe(1);
            sessionEntity.TermTypeId.ShouldBe(1);
            sessionEntity.SchoolYear.ShouldBe((short)2014);
            sessionEntity.BeginDate.ShouldBe(new DateTime(2014, 6, 26));
            sessionEntity.EndDate.ShouldBe(new DateTime(2014, 9, 26));
            sessionEntity.TotalInstructionalDays.ShouldBe(92);
        }

        [Fact]
        public void ShouldMapSessionEntityToSessionIndexViewModel()
        {
            var sessionIndexModel = new SessionIndexModel();
            var sessionEntity = new Web.Data.Entities.Session
            {
                SchoolId = 1,
                TermTypeId = 1,
                SchoolYear = 2014,
                BeginDate = new DateTime(2014, 6, 26),
                EndDate = new DateTime(2014, 9, 26),
                TotalInstructionalDays = 92
            };

            var sessionToSessionIndexModelMapper = new SessionToSessionIndexModelMapper();
            sessionToSessionIndexModelMapper.Map(sessionEntity, sessionIndexModel);

            sessionIndexModel.TermType.ShouldBe("Fall Semester");
            sessionIndexModel.SchoolYearType.ShouldBe("2013-2014");
            sessionIndexModel.BeginDate.ShouldBe(new DateTime(2014, 6, 26));
            sessionIndexModel.EndDate.ShouldBe(new DateTime(2014, 9, 26));
            sessionIndexModel.TotalInstructionalDays.ShouldBe(92);
        }
    }
}