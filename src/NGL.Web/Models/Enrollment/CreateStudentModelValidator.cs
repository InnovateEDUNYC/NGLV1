using FluentValidation;

namespace NGL.Web.Models.Enrollment
{
    public class CreateStudentModelValidator : AbstractValidator<CreateStudentModel>
    {
        public CreateStudentModelValidator()
        {
            RuleFor(csm => csm.StudentUsi).NotNull();
            RuleFor(csm => csm.FirstName).NotEmpty().Length(1, 75);
            RuleFor(csm => csm.LastName).NotEmpty().Length(1, 75);
            RuleFor(csm => csm.Address).NotEmpty().Length(1, 150);
            RuleFor(csm => csm.Address2).Length(0, 20);
            RuleFor(csm => csm.City).NotEmpty().Length(1, 30);
            RuleFor(csm => csm.Sex).NotNull();
            RuleFor(csm => csm.BirthDate).NotNull();
            RuleFor(csm => csm.Race).NotNull();
            RuleFor(csm => csm.State).NotNull();
            RuleFor(csm => csm.PostalCode).NotEmpty().Length(1, 17);
            RuleFor(csm => csm.HomeLanguage).NotNull();
            RuleFor(csm => csm.FirstParent).SetValidator(new CreateParentModelValidator());

            When(csm => csm.AddSecondParent, () => RuleFor(csm => csm.SecondParent).SetValidator(new CreateParentModelValidator()));
        }

        private class CreateParentModelValidator : AbstractValidator<CreateParentModel>
        {
            public CreateParentModelValidator()
            {
                RuleFor(pm => pm.FirstName).NotEmpty().Length(1, 75);
                RuleFor(pm => pm.LastName).NotEmpty().Length(1, 75);
                RuleFor(pm => pm.Sex).NotNull();
                RuleFor(pm => pm.RelationshipToStudent).NotNull();
                RuleFor(pm => pm.EmailAddress).Length(1, 128).EmailAddress();
                RuleFor(pm => pm.TelephoneNumber).NotNull().Length(1, 24);

                When(pm => !pm.SameAddressAsStudent, () =>
                {
                    RuleFor(pm => pm.Address).NotEmpty().Length(1, 150);
                    RuleFor(pm => pm.Address2).Length(0, 20);
                    RuleFor(pm => pm.City).NotEmpty().Length(1, 30);
                    RuleFor(pm => pm.State).NotNull();
                    RuleFor(pm => pm.PostalCode).NotEmpty().Length(1, 17);
                });
            }
        }
    }
}
