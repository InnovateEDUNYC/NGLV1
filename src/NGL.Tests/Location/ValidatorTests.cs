using System;
using System.Linq.Expressions;
using FluentValidation.TestHelper;
using NGL.Tests.Builders;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Models.Location;
using NSubstitute;
using Xunit;

namespace NGL.Tests.Location
{
    public class ValidatorTests
    {
        private IGenericRepository _genericRepository;
        private CreateModel _locationCreateModel;
        private CreateModelValidator _validator;

        [Fact]
        public void ShouldNotHaveErrorsWhenLocationDoesNotExist()
        {
            Setup();

            _genericRepository
                .Get(Arg.Any<Expression<Func<Web.Data.Entities.Location, bool>>>())
                .Returns(null as Web.Data.Entities.Location);

            _validator.ShouldNotHaveValidationErrorFor(m => m.ClassroomIdentificationCode, _locationCreateModel.ClassroomIdentificationCode);
        }

        [Fact]
        public void ShouldHaveErrorsWhenLocationExists()
        {
            Setup();
            var locationEntity = new LocationBuilder().Build();

            _genericRepository
                .Get(Arg.Any<Expression<Func<Web.Data.Entities.Location, bool>>>())
                .Returns(locationEntity);

            _validator.ShouldHaveValidationErrorFor(m => m.ClassroomIdentificationCode, _locationCreateModel.ClassroomIdentificationCode);
        }

        private void Setup()
        {
            _genericRepository = Substitute.For<IGenericRepository>();
            _locationCreateModel = new CreateLocationModelBuilder().Build();
            _validator = new CreateModelValidator(_genericRepository);
        }
       
    }
}
