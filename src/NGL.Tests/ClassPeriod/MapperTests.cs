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
        private ISchoolRepository _schoolRepository;


        [Fact]
        public void ShouldMapCreateModelToClassPeriod()
        {
            SetUp();
            var classPeriodEntity = new Web.Data.Entities.ClassPeriod();
            var classPeriodCreateModel = new CreateModel
            {
                ClassPeriodName = "Period 1"
            };

            var createModeltoClassPeriodMapper = new CreateModelToClassPeriodMapper(_schoolRepository);
            createModeltoClassPeriodMapper.Map(classPeriodCreateModel, classPeriodEntity);

            classPeriodEntity.ClassPeriodName.ShouldBe("Period 1");
            classPeriodEntity.SchoolId.ShouldBe(1);
        }

        [Fact]
        public void ShouldMapClassPeriodToIndexModel()
        {
            var classPeriodIndexModel = new IndexModel();
            var classPeriodEntity = new Web.Data.Entities.ClassPeriod
            {
                ClassPeriodName = "Period 1"
            };

            var classPeriodToIndexMapper = new ClassPeriodToIndexModelMapper();

            classPeriodToIndexMapper.Map(classPeriodEntity, classPeriodIndexModel);

            classPeriodIndexModel.ClassPeriodName.ShouldBe("Period 1");
        }

        private void SetUp()
        {
            _schoolRepository = Substitute.For<ISchoolRepository>();
            _schoolRepository.GetSchool().Returns(
                new School
                {
                    SchoolId = 1
                });
        }

    }
}