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
                FirstParent = new CreateParentModel
                {
                    FirstName = null
                }
            };
            _validator.ShouldHaveValidationErrorFor(csm => csm.FirstName, createStudentModel);
            _validator.ShouldHaveValidationErrorFor(csm => csm.FirstParent.FirstName, createStudentModel);
        } 

        [Fact]
        public void ShouldHaveErrorsForSecondParentWhenSecondParentAdded()
        {
            var createStudentModel = new CreateStudentModel()
            {
                AddSecondParent = true,
                SecondParent = new CreateParentModel()
                {
                    FirstName = null,
                    SameAddressAsStudent = false,
                    Address = null,
                    Address2 = "123456789012345678901234567890", //value is too long
                    City = null,
                    State = null,
                    PostalCode = null
                }
            };

            _validator.ShouldHaveValidationErrorFor(csm => csm.SecondParent.FirstName, createStudentModel);
            _validator.ShouldHaveValidationErrorFor(csm => csm.SecondParent.Address, createStudentModel);
            _validator.ShouldHaveValidationErrorFor(csm => csm.SecondParent.City, createStudentModel);
            _validator.ShouldHaveValidationErrorFor(csm => csm.SecondParent.State, createStudentModel);
            _validator.ShouldHaveValidationErrorFor(csm => csm.SecondParent.PostalCode, createStudentModel);

        }

        [Fact]
        public void ShouldNotHaveErrorsForAddressIfSameAsStudent()
        {
            var createStudentModel = new CreateStudentModel
            {
                Address = "something",
 
                FirstParent = new CreateParentModel
                {
                    SameAddressAsStudent = true,
                    Address = null,
                    Address2 = "123456789012345678901234567890", //value is too long
                    City = null,
                    State = null,
                    PostalCode = null
                }
            };

            _validator.ShouldNotHaveValidationErrorFor(csm => csm.FirstParent.Address, createStudentModel);             
            _validator.ShouldNotHaveValidationErrorFor(csm => csm.FirstParent.Address2, createStudentModel);                       }
    }
}
