using System;
using NGL.Web.Data.Entities;
using NGL.Web.Models;
using Shouldly;
using Xunit;

namespace NGL.Tests.Mappers
{
    public class SessionTest
    {
        [Fact]
        public void ShouldMapSessionEntityToSessionViewModel()
        {
            SessionModel sessionModel = new SessionModel();
            Session sessionEntity = new Session();
            sessionEntity.SchoolId = 1;
            sessionEntity.TermTypeId = 1;
            sessionEntity.SchoolYear = 2014;
            sessionEntity.SessionName = "Summer 2014";
            sessionEntity.BeginDate = new DateTime(2014, 6, 26);
            sessionEntity.EndDate = new DateTime(2014, 9, 26);
            sessionEntity.TotalInstructionalDays = 92;

            SessionToSessionModelMapper sessionToSessionModelMapper = new SessionToSessionModelMapper();
            sessionToSessionModelMapper.Map(sessionEntity, sessionModel);

            sessionModel.SchoolId.ShouldBe(1);
            sessionModel.TermTypeId.ShouldBe(1);
            sessionModel.SchoolYear.ShouldBe((short)2014);
            sessionModel.SessionName.ShouldBe("Summer 2014");
            sessionModel.BeginDate.ShouldBe(new DateTime(2014, 6, 26));
            sessionModel.EndDate.ShouldBe(new DateTime(2014, 9, 26));
            sessionModel.TotalInstructionalDays.ShouldBe(92);
        }
    }
}
