using System;
using System.Linq.Expressions;
using FluentValidation.TestHelper;
using NGL.Tests.Builders;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Models.ClassPeriod;
using NSubstitute;
using Xunit;

namespace NGL.Tests.ClassPeriod
{
    public class ValidatorTests
    {
        private IGenericRepository _genericRepository;
        private CreateModel _classPeriodCreateModel;
        private CreateModelValidator _validator;

        [Fact]
        public void ShouldNotHaveErrorsIfClassPeriodDoesNotExist()
        {
            Setup();

            _genericRepository
                .Get(Arg.Any<Expression<Func<Web.Data.Entities.ClassPeriod, bool>>>())
                .Returns(null as Web.Data.Entities.ClassPeriod);

            _validator.ShouldNotHaveValidationErrorFor(m => m.ClassPeriodName, _classPeriodCreateModel.ClassPeriodName);
        }

        [Fact]
        public void ShouldHaveErrorsIfClassPeriodExists()
        {
            Setup();
            var classPeriodEntity = new ClassPeriodBuilder().Build();

            _genericRepository
                .Get(Arg.Any<Expression<Func<Web.Data.Entities.ClassPeriod, bool>>>())
                .Returns(classPeriodEntity);

            _validator.ShouldHaveValidationErrorFor(m => m.ClassPeriodName, _classPeriodCreateModel.ClassPeriodName);
        }

        private void Setup()
        {
            _genericRepository = Substitute.For<IGenericRepository>();
            _classPeriodCreateModel = new CreateClassPeriodModelBuilder().Build();
            _validator = new CreateModelValidator(_genericRepository);   
        }
    }
}
