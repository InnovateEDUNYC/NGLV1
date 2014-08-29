using FluentValidation;

namespace NGL.Web.Models.Student
{
    public class HomeAddressModelValidator : AbstractValidator<HomeAddressModel>
    {
        public HomeAddressModelValidator()
        {
            RuleFor(csm => csm.StudentUsi).NotNull().NotEqual(0);
            RuleFor(csm => csm.Address).NotEmpty().Length(1, 150);
            RuleFor(csm => csm.Address2).Length(0, 20);
            RuleFor(csm => csm.City).NotEmpty().Length(1, 30);
            RuleFor(csm => csm.State).NotNull();
            RuleFor(csm => csm.PostalCode).NotEmpty().Length(1, 17);
        }
    }
}