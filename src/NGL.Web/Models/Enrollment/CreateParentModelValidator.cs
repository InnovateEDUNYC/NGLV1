using FluentValidation;

namespace NGL.Web.Models.Enrollment
{
    public class CreateParentModelValidator : AbstractValidator<CreateParentModel>
    {
        public CreateParentModelValidator()
        {
            RuleFor(pm => pm.FirstName).NotEmpty().Length(1, 75);
            RuleFor(pm => pm.LastName).NotEmpty().Length(1, 75);
            RuleFor(pm => pm.Sex).NotNull();
            RuleFor(pm => pm.RelationshipToStudent).NotNull();
            RuleFor(pm => pm.EmailAddress).Length(0, 128);
            RuleFor(pm => pm.TelephoneNumber).Length(0, 24);

            When(pm => !pm.SameAddressAsStudent, () =>
            {
                RuleFor(pm => pm.Address).NotEmpty().Length(1, 150);
                RuleFor(pm => pm.Address2).Length(0, 20);
                RuleFor(pm => pm.City).NotEmpty();
                RuleFor(pm => pm.State).NotNull();
                RuleFor(pm => pm.PostalCode).NotEmpty().Length(1, 17);
            });
        }
    }
}