using FluentValidation;

namespace NGL.Web.Models.Student
{
    public class NameModelValidator : AbstractValidator<NameModel>
    {
        public NameModelValidator()
        {
            RuleFor(nm => nm.FirstName).NotEmpty().Length(1, 75);
            RuleFor(nm => nm.LastName).NotEmpty().Length(1, 75);
            RuleFor(nm => nm.StudentUsi).NotNull().NotEqual(0);
        }   
    }
}