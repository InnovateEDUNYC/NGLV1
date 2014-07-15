using FluentValidation.TestHelper;
using NGL.Web.Models.Enrollment;
using Xunit;

namespace NGL.Tests.Enrollment
{
    public class CreateParentModelValidatorTest
    {
        private readonly CreateParentModelValidator _validator;

        public CreateParentModelValidatorTest()
        {
            _validator = new CreateParentModelValidator();
        }

        [Fact]
        public void ShouldHaveErrorIfModelNotvalid()
        {
            _validator.ShouldHaveValidationErrorFor(parent => parent.FirstName, null as string);
            _validator.ShouldHaveValidationErrorFor(parent => parent.FirstName, "123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890");
        }

        [Fact]
        public void ShouldNotHaveErrorsForAddressIfSameAsStudent()
        {
            var parentModel = new CreateParentModel
            {
                SameAddressAsStudent = true,
                Address = null,
                Address2 = "123456789012345678901234567890",
                City = null,
                State = null,
                PostalCode = null
            };

            _validator.ShouldNotHaveValidationErrorFor(p => p.Address, parentModel);
            _validator.ShouldNotHaveValidationErrorFor(p => p.Address2, parentModel);
            _validator.ShouldNotHaveValidationErrorFor(p => p.City, parentModel);
            _validator.ShouldNotHaveValidationErrorFor(p => p.State, parentModel);
            _validator.ShouldNotHaveValidationErrorFor(p => p.PostalCode, parentModel);
        }
        
        [Fact]
        public void ShouldNotErrorsForAddressIfSameAsStudent()
        {
            var parentModel = new CreateParentModel
            {
                SameAddressAsStudent = false,
                Address = null,
                Address2 = "123456789012345678901234567890",
                City = null,
                State = null,
                PostalCode = null
            };

            _validator.ShouldHaveValidationErrorFor(p => p.Address, parentModel);
            _validator.ShouldHaveValidationErrorFor(p => p.Address2, parentModel);
            _validator.ShouldHaveValidationErrorFor(p => p.City, parentModel);
            _validator.ShouldHaveValidationErrorFor(p => p.State, parentModel);
            _validator.ShouldHaveValidationErrorFor(p => p.PostalCode, parentModel);
        }
    }
}
