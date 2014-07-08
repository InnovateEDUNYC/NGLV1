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
            schoolRepository.GetSchool().Returns(new School{SchoolId = 1});

            var sessionEntity = new Web.Data.Entities.Session();
            var sessionCreateModel = new CreateModel
            {
                Term = TermTypeEnum.FallSemester,
                SchoolYear = SchoolYearTypeEnum.Year2014,
                BeginDate = new DateTime(2014, 6, 26),
                EndDate = new DateTime(2014, 9, 26),
                TotalInstructionalDays = 92
            };

            var createModelToEntityMapper = new CreateModelToSessionMapper(schoolRepository);
            createModelToEntityMapper.Map(sessionCreateModel, sessionEntity);

            sessionEntity.SchoolId.ShouldBe(1);
            sessionEntity.TermTypeId.ShouldBe((int) TermTypeEnum.FallSemester);
            sessionEntity.SchoolYear.ShouldBe((short) SchoolYearTypeEnum.Year2014);
            sessionEntity.BeginDate.ShouldBe(new DateTime(2014, 6, 26));
            sessionEntity.EndDate.ShouldBe(new DateTime(2014, 9, 26));
            sessionEntity.TotalInstructionalDays.ShouldBe(92);
        }

        [Fact]
        public void ShouldMapEntityToIndexModel()
        {
            var sessionIndexModel = new IndexModel();
            var sessionEntity = new Web.Data.Entities.Session
            {
                SchoolId = 1,
                TermTypeId = (int) TermTypeEnum.FallSemester,
                SchoolYear = (int) SchoolYearTypeEnum.Year2014,
                BeginDate = new DateTime(2014, 6, 26),
                EndDate = new DateTime(2014, 9, 26),
                TotalInstructionalDays = 92
            };

            var entityToIndexModelMapper = new SessionToIndexModelMapper();
            entityToIndexModelMapper.Map(sessionEntity, sessionIndexModel);

            sessionIndexModel.Term.ShouldBe(TermTypeEnum.FallSemester.Humanize());
            sessionIndexModel.SchoolYear.ShouldBe(SchoolYearTypeEnum.Year2014.Humanize());
            sessionIndexModel.BeginDate.ShouldBe(new DateTime(2014, 6, 26));
            sessionIndexModel.EndDate.ShouldBe(new DateTime(2014, 9, 26));
            sessionIndexModel.TotalInstructionalDays.ShouldBe(92);
        }
    }
}