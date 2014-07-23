using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using FluentValidation.Results;
using FluentValidation.Validators;
using Microsoft.Ajax.Utilities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Queries;
using NGL.Web.Infrastructure;


namespace NGL.Web.Models.Enrollment
{
    public class AcademicDetailModelValidator : AbstractValidator<AcademicDetailModel>
    {
        private readonly IGenericRepository _genericRepository;

        public AcademicDetailModelValidator(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;


            RuleFor(adm => adm.Reading).NotNull().GreaterThanOrEqualTo(0).SetValidator(new ScalePrecisionValidator(2,7));
            RuleFor(adm => adm.Math).NotNull().GreaterThanOrEqualTo(0).SetValidator(new ScalePrecisionValidator(2,7));
            RuleFor(adm => adm.Writing).NotNull().GreaterThanOrEqualTo(0).SetValidator(new ScalePrecisionValidator(2,7));
            RuleFor(adm => adm.AnticipatedGrade).NotNull();
            RuleFor(adm => adm.PerformanceHistory).Length(0, 4000);
            RuleFor(adm => adm.EntryDate).NotNull();
        }

        public override ValidationResult Validate(ValidationContext<AcademicDetailModel> context)
        {
            var result = base.Validate(context);
            return new ValidationResult(result.Errors.Union(ValidateExistence(context.InstanceToValidate)));
        }

        private IEnumerable<ValidationFailure> ValidateExistence(AcademicDetailModel academicDetailModel)
        {
            var query = new StudentAcademicDetailsByStudentUsiAndSchoolYearQuery(academicDetailModel.StudentUsi, (short)academicDetailModel.SchoolYear);

            if (_genericRepository.Get(query) != null)
            {
                yield return new ValidationFailure(academicDetailModel.GetNameFor(adm => adm.SchoolYear), "A record for this student for this year already exists");
            }
        }
    }
}