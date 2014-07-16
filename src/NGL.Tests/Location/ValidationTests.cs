using System;
using System.Linq.Expressions;
using FluentValidation.TestHelper;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Models.Location;
using NSubstitute;
using Xunit;

namespace NGL.Tests.Location
{
    public class ValidationTests
    {
        [Fact]
        public void ShouldReturnTrueIfLocationDoesNotExist()
        {
            var genericRepository = Substitute.For<IGenericRepository>();
            var locationCreateModel = new CreateModel()
            {
                ClassroomIdentificationCode = "BKL200"
            };

            var validator = new CreateModelValidator(genericRepository);

            genericRepository
                .Get(Arg.Any<Expression<Func<Web.Data.Entities.Location, bool>>>())
                .Returns(null as Web.Data.Entities.Location);

            validator.ShouldNotHaveValidationErrorFor(m => m.ClassroomIdentificationCode, locationCreateModel.ClassroomIdentificationCode);
            
        }

        [Fact]
        public void ShouldReturnFalseIfLocationExists()
        {
            var genericRepository = Substitute.For<IGenericRepository>();
            var locationCreateModel = new CreateModel()
            {
                ClassroomIdentificationCode = "BKL200"
            };

            var validator = new CreateModelValidator(genericRepository);

            var locationEntity = new Web.Data.Entities.Location
            {
                ClassroomIdentificationCode = "BKL200"
            };

            genericRepository
                .Get(Arg.Any<Expression<Func<Web.Data.Entities.Location, bool>>>())
                .Returns(locationEntity);

            validator.ShouldHaveValidationErrorFor(m => m.ClassroomIdentificationCode, locationCreateModel.ClassroomIdentificationCode);
            
        }
       
    }
}
