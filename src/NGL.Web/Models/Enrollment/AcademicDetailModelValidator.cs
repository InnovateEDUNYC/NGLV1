using System.Data;
using FluentValidation;
using FluentValidation.Validators;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Models.Enrollment
{
    public class AcademicDetailModelValidator : AbstractValidator<AcademicDetailModel>
    {
        public AcademicDetailModelValidator(IGenericRepository genericRepository)
        {
//            var existenceValidator = new ExistenceValidator<AcademicDetailModel>(genericRepository);
            RuleFor(adm => adm.Reading).NotNull().GreaterThanOrEqualTo(0).SetValidator(new ScalePrecisionValidator(2,7));
            RuleFor(adm => adm.Math).NotNull().GreaterThanOrEqualTo(0).SetValidator(new ScalePrecisionValidator(2,7));
            RuleFor(adm => adm.Writing).NotNull().GreaterThanOrEqualTo(0).SetValidator(new ScalePrecisionValidator(2,7));
            RuleFor(adm => adm.AnticipatedGrade).NotNull();
            RuleFor(adm => adm.PerformanceHistory).Length(0, 4000);

        }
    }
}