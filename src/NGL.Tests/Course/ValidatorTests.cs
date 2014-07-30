using System;
using System.Linq.Expressions;
using FluentValidation.TestHelper;
using NGL.Tests.Builders;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Models.Course;
using NSubstitute;
using Xunit;

namespace NGL.Tests.Course
{
    public class ValidatorTests
    {
        private IGenericRepository _genericRepository;
        private CreateModel _courseCreateModel;
        private CreateModelValidator _validator;

        [Fact]
        public void ShouldNotHaveErrorsIfCourseDoesNotExist()
        {
            Setup();

            _genericRepository
                .Get(Arg.Any<Expression<Func<Web.Data.Entities.Course, bool>>>())
                .Returns(null as Web.Data.Entities.Course);

            _validator.ShouldNotHaveValidationErrorFor(c => c.CourseCode, _courseCreateModel.CourseCode);
        }

        [Fact]
        public void ShouldHaveErrorsIfCourseExists()
        {
            Setup();
            var courseEntity = new CourseBuilder().Build();

            _genericRepository
                .Get(Arg.Any<Expression<Func<Web.Data.Entities.Course, bool>>>())
                .Returns(courseEntity);

            _validator.ShouldHaveValidationErrorFor(c => c.CourseCode, _courseCreateModel.CourseCode);
        }

        private void Setup()
        {
            _genericRepository = Substitute.For<IGenericRepository>();
            _courseCreateModel = new CreateCourseModelBuilder().Build();
            _validator = new CreateModelValidator(_genericRepository);
        }
    }
}
