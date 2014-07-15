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
            RuleFor(csm => csm.Address).NotEmpty().Length(1,150);
            RuleFor(csm => csm.Address2).Length(0,20);
            RuleFor(csm => csm.City).NotEmpty();
            RuleFor(csm => csm.Sex).NotNull();
            RuleFor(csm => csm.BirthDate).NotNull();
            RuleFor(csm => csm.Race).NotNull();
            RuleFor(csm => csm.State).NotNull();
            RuleFor(csm => csm.PostalCode).NotEmpty().Length(1,17);
            RuleFor(csm => csm.HomeLanguage).NotNull();
            RuleFor(csm => csm.FirstParent).SetValidator(new CreateParentModelValidator());
        }
    }
}