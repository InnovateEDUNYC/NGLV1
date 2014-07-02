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
        public void ShouldMapSessionEntityToSessionViewModel()
        {
            var sessionModel = new SessionModel();
            var sessionEntity = new Web.Data.Entities.Session
            {
                SchoolId = 1,
                TermTypeId = 1,
                SchoolYear = 2014,
                SessionName = "Summer 2014",
                BeginDate = new DateTime(2014, 6, 26),
                EndDate = new DateTime(2014, 9, 26),
                TotalInstructionalDays = 92
            };

            var sessionToSessionModelMapper = new SessionToSessionModelMapper();
            sessionToSessionModelMapper.Map(sessionEntity, sessionModel);

            sessionModel.TermTypeId.ShouldBe(1);
            sessionModel.SchoolYear.ShouldBe((short)2014);
            sessionModel.SessionName.ShouldBe("Summer 2014");
            sessionModel.BeginDate.ShouldBe(new DateTime(2014, 6, 26));
            sessionModel.EndDate.ShouldBe(new DateTime(2014, 9, 26));
            sessionModel.TotalInstructionalDays.ShouldBe(92);
        }

        [Fact]
        public void ShouldMapSessionViewModelToSessionEntity()
        {
            var schoolRepository = Substitute.For<ISchoolRepository>();
            schoolRepository.GetSchool().Returns(new School{SchoolId = 1});

            var sessionEntity = new Web.Data.Entities.Session();
            var sessionModel = new SessionModel
            {
                TermTypeId = 1,
                SchoolYear = 2014,
                SessionName = "Summer 2014",
                BeginDate = new DateTime(2014, 6, 26),
                EndDate = new DateTime(2014, 9, 26),
                TotalInstructionalDays = 92
            };

            var sessionModelToSessionMapper = new SessionModelToSessionMapper(schoolRepository);
            sessionModelToSessionMapper.Map(sessionModel, sessionEntity);

            sessionEntity.SchoolId.ShouldBe(1);
            sessionEntity.TermTypeId.ShouldBe(1);
            sessionEntity.SchoolYear.ShouldBe((short)2014);
            sessionEntity.SessionName.ShouldBe("Summer 2014");
            sessionEntity.BeginDate.ShouldBe(new DateTime(2014, 6, 26));
            sessionEntity.EndDate.ShouldBe(new DateTime(2014, 9, 26));
            sessionEntity.TotalInstructionalDays.ShouldBe(92);
        }
    }
}