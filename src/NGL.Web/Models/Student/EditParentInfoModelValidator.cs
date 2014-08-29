using FluentValidation;

namespace NGL.Web.Models.Student
{
    public class EditProfileParentModelValidator : AbstractValidator<EditableParentModel>
    {
        public EditProfileParentModelValidator()
        {
            RuleFor(pm => pm.FirstName).NotEmpty().Length(1, 75);
            RuleFor(pm => pm.LastName).NotEmpty().Length(1, 75);
            RuleFor(pm => pm.Sex).NotNull();
            RuleFor(pm => pm.EmailAddress).Length(1, 128).EmailAddress();
            RuleFor(pm => pm.TelephoneNumber).NotNull().Length(1, 24);
        }
    }
}