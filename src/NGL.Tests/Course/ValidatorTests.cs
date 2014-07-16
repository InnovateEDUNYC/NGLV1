using System;
using System.Linq.Expressions;
using FluentValidation.TestHelper;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Models.Course;
using NSubstitute;
using Xunit;

namespace NGL.Tests.Course
{
    public class ValidatorTests
    {
        [Fact]
        public void ShouldNotHaveErrorsIfCourseDoesNotExist()
        {
            var genericRepository = Substitute.For<IGenericRepository>();
            var courseCreateModel = new CreateModel
            {
                CourseCode = "Math101",
                CourseTitle = "Pre-Algebra",
                NumberOfParts = 1
            };

            var validator = new CreateModelValidator(genericRepository);

            genericRepository
                .Get(Arg.Any<Expression<Func<Web.Data.Entities.Course, bool>>>())
                .Returns(null as Web.Data.Entities.Course);

            validator.ShouldNotHaveValidationErrorFor(c => c.CourseCode, courseCreateModel.CourseCode);
        }

        [Fact]
        public void ShouldHaveErrorsIfCourseExists()
        {
            var genericRepository = Substitute.For<IGenericRepository>();
            var courseCreateModel = new CreateModel
            {
                CourseCode = "Math101",
                CourseTitle = "Pre-Algebra",
                NumberOfParts = 1
            };

            var validator = new CreateModelValidator(genericRepository);

            var courseEntity = new Web.Data.Entities.Course
            {
                CourseCode = "Math101",
                CourseTitle = "Pre-Algebra",
                NumberOfParts = 1
            };

            genericRepository
                .Get(Arg.Any<Expression<Func<Web.Data.Entities.Course, bool>>>())
                .Returns(courseEntity);

            validator.ShouldHaveValidationErrorFor(c => c.CourseCode, courseCreateModel.CourseCode);
        }
    }
}
