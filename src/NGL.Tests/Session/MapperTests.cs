using System;
using Humanizer;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Repositories;
using NGL.Web.Models.Session;
using NSubstitute;
using Shouldly;
using Xunit;

namespace NGL.Tests.Session
{
    public class MapperTests
    {
        [Fact]
        public void ShouldMapCreateModelToEntity()
        {
            var schoolRepository = Substitute.For<ISchoolRepository>();
            schoolRepository.GetSchool().Returns(new School { SchoolId = Constants.SchoolId });

            var sessionCreateModel = new CreateModelBuilder().Build();
            var sessionEntity = new CreateModelToSessionMapper(schoolRepository).Build(sessionCreateModel);

            sessionEntity.SchoolId.ShouldBe(Constants.SchoolId);
            sessionEntity.TermTypeId.ShouldBe((int) sessionCreateModel.Term);
            sessionEntity.SchoolYear.ShouldBe((short) sessionCreateModel.SchoolYear);
            sessionEntity.BeginDate.ShouldBe((DateTime) sessionCreateModel.BeginDate);
            sessionEntity.EndDate.ShouldBe((DateTime) sessionCreateModel.EndDate);
            sessionEntity.TotalInstructionalDays.ShouldBe((int) sessionCreateModel.TotalInstructionalDays);
        }

        [Fact]
        public void ShouldMapEntityToIndexModel()
        {
            var sessionEntity = new SessionBuilder().Build();
            var sessionIndexModel = new SessionToIndexModelMapper().Build(sessionEntity);

            sessionIndexModel.Term.ShouldBe(((TermTypeEnum) sessionEntity.TermTypeId).Humanize());
            sessionIndexModel.SchoolYear.ShouldBe(((SchoolYearTypeEnum) sessionEntity.SchoolYear).Humanize());
            sessionIndexModel.BeginDate.ShouldBe(sessionEntity.BeginDate);
            sessionIndexModel.EndDate.ShouldBe(sessionEntity.EndDate);
            sessionIndexModel.TotalInstructionalDays.ShouldBe(sessionEntity.TotalInstructionalDays);
        }
    }
}