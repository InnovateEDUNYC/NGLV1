using FluentValidation.TestHelper;
using NGL.Web.Models.Enrollment;
using Xunit;

namespace NGL.Tests.Enrollment
{
    public class CreateStudentModelValidatorTests
    {
        private readonly CreateStudentModelValidator _validator;

        public CreateStudentModelValidatorTests()
        {
            _validator = new CreateStudentModelValidator();
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
    }
}
