using System;
using Moq;
using Moq.Language.Flow;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Repositories;
using NGL.Web.Models.Session;
using Shouldly;
using Xunit;

namespace NGL.Tests.Mappers
{
    public class SessionTest
    {

        [Fact]
        public void ShouldMapSessionEntityToSessionViewModel()
        {
            var sessionModel = new SessionModel();
            var sessionEntity = new Session
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
            var mockSchoolRepository = new Mock<ISchoolRepository>();
            mockSchoolRepository.Setup(repo => repo.GetSchool()).Returns(new School{SchoolId = 1});

            ISchoolRepository schoolRepository = mockSchoolRepository.Object;

            var sessionEntity = new Session();
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
