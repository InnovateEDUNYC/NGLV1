using System;
using System.Linq.Expressions;
using FluentValidation.TestHelper;
using NGL.Web.Models;
using NGL.Web.Models.Enrollment;
using NSubstitute;
using Xunit;

namespace NGL.Tests.Enrollment
{
    public class CreateStudentModelValidatorTests
    {
        private readonly CreateStudentModelValidator _validator;

        public CreateStudentModelValidatorTests()
        {
            var repoReader = Substitute.For<IRepositoryReader<Web.Data.Entities.Student>>();
            repoReader.DoesRepositoryReturnNullFor(Arg.Any<int?>(),
                Arg.Any<Expression<Func<Web.Data.Entities.Student, bool>>>()).Returns(false);
            _validator = new CreateStudentModelValidator(repoReader);
        }
        [Fact]
        public void ShouldHaveErrorsIfModelNotValid()
        {
            var createStudentModel = new CreateStudentModel
            {
                FirstName = null,
            };

            _validator.ShouldHaveValidationErrorFor(csm => csm.FirstName, createStudentModel);
        }

        [Fact]
        public void ShouldHaveErrorIfStudentAlreadyExists()
        {
            var createStudentModel = new CreateStudentModel
            {
                StudentUsi = 234
            };

            _validator.ShouldHaveValidationErrorFor(csm => csm.StudentUsi, createStudentModel);
        }
    }
}
