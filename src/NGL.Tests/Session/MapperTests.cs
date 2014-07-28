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
        private ISchoolRepository _schoolRepository;
        private CreateModelToSessionMapper _createModelToEntityMapper;
        private SessionToIndexModelMapper _entityToIndexModelMapper;

        private void Setup()
        {
            _schoolRepository = Substitute.For<ISchoolRepository>();
            _schoolRepository.GetSchool().Returns(new School { SchoolId = Constants.SchoolId });
            _createModelToEntityMapper = new CreateModelToSessionMapper(_schoolRepository);
            _entityToIndexModelMapper = new SessionToIndexModelMapper();
        }

        [Fact]
        public void ShouldMapCreateModelToEntity()
        {
            Setup();

            var sessionCreateModel = new CreateModelBuilder().Build();
            var sessionEntity = _createModelToEntityMapper.Build(sessionCreateModel);

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
            Setup();

            var sessionEntity = new SessionBuilder().Build();
            var sessionIndexModel = _entityToIndexModelMapper.Build(sessionEntity);

            sessionIndexModel.Term.ShouldBe(((TermTypeEnum) sessionEntity.TermTypeId).Humanize());
            sessionIndexModel.SchoolYear.ShouldBe(((SchoolYearTypeEnum) sessionEntity.SchoolYear).Humanize());
            sessionIndexModel.BeginDate.ShouldBe(sessionEntity.BeginDate);
            sessionIndexModel.EndDate.ShouldBe(sessionEntity.EndDate);
            sessionIndexModel.TotalInstructionalDays.ShouldBe(sessionEntity.TotalInstructionalDays);
        }
    }
}