using NGL.Web.Data.Entities;
using NGL.Web.Data.Repositories;
using NGL.Web.Models.ClassPeriod;
using NSubstitute;
using Shouldly;
using Xunit;

namespace NGL.Tests.ClassPeriod
{
    public class MapperTests
    {


        [Fact]
        public void ShouldMapCreateModelToClassPeriod()
        {
            var schoolRepository = Substitute.For<ISchoolRepository>();
            schoolRepository.GetSchool().Returns(
                new School
                {
                    SchoolId = 1
                });

            var classPeriodEntity = new Web.Data.Entities.ClassPeriod();
            var classPeriodCreateModel = new CreateModel
            {
                ClassPeriodName = "Period 1"
            };

            var createModeltoClassPeriodMapper = new CreateModelToClassPeriodMapper(schoolRepository);
            createModeltoClassPeriodMapper.Map(classPeriodCreateModel, classPeriodEntity);

            classPeriodEntity.ClassPeriodName.ShouldBe("Period 1");
            classPeriodEntity.SchoolId.ShouldBe(1);
        }

    }
}