using FluentValidation;

namespace NGL.Web.Models.Student
{
    public class EditProfileParentModelValidator : AbstractValidator<EditProfileParentModel>
    {
        public EditProfileParentModelValidator()
        {
            RuleFor(pm => pm.FirstName).NotEmpty().Length(1, 75);
            RuleFor(pm => pm.LastName).NotEmpty().Length(1, 75);
            RuleFor(pm => pm.Sex).NotNull();
            RuleFor(pm => pm.EmailAddress).Length(1, 128).EmailAddress();
            RuleFor(pm => pm.TelephoneNumber).NotNull().Length(1, 24);
            When(pm => !pm.SameAddressAsStudent,
                () => RuleFor(pm => pm.EditableParentAddressModel).SetValidator(new ParentAddressValidator()));
        }

        private class ParentAddressValidator : AbstractValidator<EditableParentAddressModel>
        {
            public ParentAddressValidator()
            {
                RuleFor(pm => pm.Address).NotEmpty().Length(1, 150);
                RuleFor(pm => pm.Address2).Length(0, 20);
                RuleFor(pm => pm.City).NotEmpty().Length(1, 30);
                RuleFor(pm => pm.State).NotNull();
                RuleFor(pm => pm.PostalCode).NotEmpty().Length(1, 17);
            }
        }
    }
}