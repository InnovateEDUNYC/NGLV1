using System;
using System.Linq.Expressions;
using FluentValidation.TestHelper;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Models.ClassPeriod;
using NSubstitute;
using Xunit;

namespace NGL.Tests.ClassPeriod
{
    public class ValidatorTests
    {
        [Fact]
        public void ShouldNotHaveErrorsIfClassPeriodDoesNotExist()
        {
            var genericRepository = Substitute.For<IGenericRepository>();
            var classPeriodCreateModel = new CreateModel
            {
                ClassPeriodName = "Period 1"
            };

            var validator = new CreateModelValidator(genericRepository);

            genericRepository
                .Get(Arg.Any<Expression<Func<Web.Data.Entities.ClassPeriod, bool>>>())
                .Returns(null as Web.Data.Entities.ClassPeriod);

            validator.ShouldNotHaveValidationErrorFor(m => m.ClassPeriodName, classPeriodCreateModel.ClassPeriodName);
        }

        [Fact]
        public void ShouldHaveErrorsIfClassPeriodExists()
        {
            var genericRepository = Substitute.For<IGenericRepository>();
            var classPeriodCreateModel = new CreateModel
            {
                ClassPeriodName = "Period 1"
            };

            var validator = new CreateModelValidator(genericRepository);

            var classPeriodEntity = new Web.Data.Entities.ClassPeriod
            {
                ClassPeriodName = "Period 1"
            };

            genericRepository
                .Get(Arg.Any<Expression<Func<Web.Data.Entities.ClassPeriod, bool>>>())
                .Returns(classPeriodEntity);

            validator.ShouldHaveValidationErrorFor(m => m.ClassPeriodName, classPeriodCreateModel.ClassPeriodName);
        }
    }
}
