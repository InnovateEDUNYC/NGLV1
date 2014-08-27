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

            var model = new CreateSessionModelBuilder().Build();
            var entity = new CreateModelToSessionMapper(schoolRepository).Build(model);

            entity.SchoolId.ShouldBe(Constants.SchoolId);
            entity.TermTypeId.ShouldBe((int) model.Term.GetValueOrDefault());
            entity.SchoolYear.ShouldBe((short) model.SchoolYear);
            entity.BeginDate.ShouldBe(model.BeginDate.GetValueOrDefault());
            entity.EndDate.ShouldBe(model.EndDate.GetValueOrDefault());
            entity.TotalInstructionalDays.ShouldBe(model.TotalInstructionalDays.GetValueOrDefault());
            entity.SessionName.ShouldBe("Fall Semester 2013-2014");
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