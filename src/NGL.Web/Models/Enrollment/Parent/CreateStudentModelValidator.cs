using System.Web.Mvc;
using FluentValidation;
using FluentValidation.Results;
using NGL.Web.Models.Enrollment.Student;

namespace NGL.Web.Models.Enrollment.Parent
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


            RuleFor(csm => csm.FirstParent).SetValidator(new ParentModelValidator());
        }
    }
    
    public class ParentModelValidator : AbstractValidator<ParentEnrollmentInfoModel>
    {
        public ParentModelValidator()
        {
            RuleFor(pm => pm.FirstName).NotEmpty().Length(1, 75);
            RuleFor(pm => pm.LastName).NotEmpty().Length(1, 75);
            RuleFor(pm => pm.Sex).NotNull();
            RuleFor(pm => pm.RelationshipToStudent).NotNull();
            RuleFor(pm => pm.EmailAddress).Length(0, 128);
            RuleFor(pm => pm.TelephoneNumber).Length(0, 24);

            When(pm => !pm.SameAddressAsStudent, () =>
            {
                RuleFor(pm => pm.ParentAddress).NotEmpty().Length(1, 150);
                RuleFor(pm => pm.Address2).Length(0, 20);
                RuleFor(pm => pm.City).NotEmpty();
                RuleFor(pm => pm.State).NotNull();
                RuleFor(pm => pm.PostalCode).NotEmpty().Length(1, 17);
            });
        }
    }
}