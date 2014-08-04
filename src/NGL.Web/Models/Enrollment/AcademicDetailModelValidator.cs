using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using FluentValidation.Results;
using FluentValidation.Validators;
using Microsoft.Ajax.Utilities;
using NGL.Web.Data.Entities;
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

            RuleFor(adm => adm.Reading).GreaterThanOrEqualTo(0).SetValidator(new ScalePrecisionValidator(2,7));
            RuleFor(adm => adm.Math).GreaterThanOrEqualTo(0).SetValidator(new ScalePrecisionValidator(2,7));
            RuleFor(adm => adm.Writing).GreaterThanOrEqualTo(0).SetValidator(new ScalePrecisionValidator(2,7));
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
            foreach (var validationFailure in ValidateStudentAcademicDetailExistence(academicDetailModel)) yield return validationFailure;

            foreach (var validationFailure in ValidateStudentSchoolAssociationExistence(academicDetailModel)) yield return validationFailure;
        }

        private IEnumerable<ValidationFailure> ValidateStudentSchoolAssociationExistence(AcademicDetailModel academicDetailModel)
        {
            var result = _genericRepository.Get<StudentSchoolAssociation>(
                ssa => ssa.EntryDate == academicDetailModel.EntryDate &&
                       ssa.StudentUSI == academicDetailModel.StudentUsi);

            if (result != null)
            {
                yield return
                    new ValidationFailure(academicDetailModel.GetNameFor(adm => adm.EntryDate),
                        "A record for this entry date already exists");
            }
        }

        private IEnumerable<ValidationFailure> ValidateStudentAcademicDetailExistence(AcademicDetailModel academicDetailModel)
        {
            var query = new StudentAcademicDetailsByStudentUsiAndSchoolYearQuery(academicDetailModel.StudentUsi,
                (short) academicDetailModel.SchoolYear);

            if (_genericRepository.Get(query) != null)
            {
                yield return
                    new ValidationFailure(academicDetailModel.GetNameFor(adm => adm.SchoolYear),
                        "A record for this student for this year already exists");
            }
        }
    }
}