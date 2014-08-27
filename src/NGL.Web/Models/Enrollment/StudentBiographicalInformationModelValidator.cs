using FluentValidation;

namespace NGL.Web.Models.Enrollment
{
    public class StudentBiographicalInformationModelValidator : AbstractValidator<EditStudentBiographicalInfoModel>
    {
        public StudentBiographicalInformationModelValidator()
        {
            RuleFor(bim => bim.Sex).NotNull();
            RuleFor(bim => bim.BirthDate).NotNull();
            RuleFor(bim => bim.Race).NotNull();
            RuleFor(bim => bim.HomeLanguage).NotNull();
        }
    }
}