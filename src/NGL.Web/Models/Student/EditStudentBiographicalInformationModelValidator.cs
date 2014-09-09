using FluentValidation;

namespace NGL.Web.Models.Student
{
    public class EditStudentBiographicalInformationModelValidator : AbstractValidator<EditableStudentBiographicalInfoModel>
    {
        public EditStudentBiographicalInformationModelValidator()
        {
            RuleFor(bim => bim.Sex).NotNull();
            RuleFor(bim => bim.BirthDate).NotNull();
            RuleFor(bim => bim.Race).NotNull();
            RuleFor(bim => bim.HomeLanguage).NotNull();
            RuleFor(bim => bim.StudentUsi).NotNull().NotEqual(0);
        }
    }
}