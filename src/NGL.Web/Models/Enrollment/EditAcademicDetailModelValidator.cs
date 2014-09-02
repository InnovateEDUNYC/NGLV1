using FluentValidation;
using FluentValidation.Validators;

namespace NGL.Web.Models.Enrollment
{
    public class EditAcademicDetailModelValidator : AbstractValidator<EditAcademicDetailModel>
    {
        public EditAcademicDetailModelValidator()
        {
            RuleFor(adm => adm.ReadingScore).GreaterThanOrEqualTo(0).SetValidator(new ScalePrecisionValidator(2, 7));
            RuleFor(adm => adm.MathScore).GreaterThanOrEqualTo(0).SetValidator(new ScalePrecisionValidator(2, 7));
            RuleFor(adm => adm.WritingScore).GreaterThanOrEqualTo(0).SetValidator(new ScalePrecisionValidator(2, 7));
            RuleFor(adm => adm.PerformanceHistory).Length(0, 4000);
        }
    }
}