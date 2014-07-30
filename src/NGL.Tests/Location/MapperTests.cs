using NGL.Web.Data.Entities;
using NGL.Web.Data.Repositories;
using NGL.Web.Models.Location;
using NSubstitute;
using Shouldly;
using Xunit;
using CreateModel = NGL.Web.Models.Location.CreateModel;
using IndexModel = NGL.Web.Models.Location.IndexModel;

namespace NGL.Tests.Location
{
    public class MapperTests
    {
        private ISchoolRepository _schoolRepository;

        [Fact]
        public void ShouldMapCreateModelToLocation()
        {
            _schoolRepository = Substitute.For<ISchoolRepository>();
            _schoolRepository.GetSchool().Returns(
                new School
                {
                    SchoolId = 1
                });

            var locationEntity = new Web.Data.Entities.Location();
            var locationCreateModel = new CreateModel
            {
                ClassroomIdentificationCode = "BKL200",
                MaximumNumberOfSeats = 50,
                OptimalNumberOfSeats = 30
            };

            var createModelToLocationMapper = new CreateModelToLocationMapper(_schoolRepository);
            createModelToLocationMapper.Map(locationCreateModel, locationEntity);

            locationEntity.ClassroomIdentificationCode.ShouldBe("BKL200");
            locationEntity.MaximumNumberOfSeats.ShouldBe(50);
            locationEntity.OptimalNumberOfSeats.ShouldBe(30);
            locationEntity.SchoolId.ShouldBe(1);
        }


        [Fact]
        public void ShouldMapLocationToIndexModel()
        {
            var locationIndexModel = new IndexModel();
            var locationEntity = new Web.Data.Entities.Location
            {
                ClassroomIdentificationCode = "BKL200",
                MaximumNumberOfSeats = 50,
                OptimalNumberOfSeats = 30
            };

            var locationToIndexMapper = new LocationToIndexModelMapper();
            locationToIndexMapper.Map(locationEntity, locationIndexModel);

            locationIndexModel.ClassroomIdentificationCode.ShouldBe("BKL200");
            locationIndexModel.MaximumNumberOfSeats.ShouldBe(50);
            locationIndexModel.OptimalNumberOfSeats.ShouldBe(30);
        }

    }
}
