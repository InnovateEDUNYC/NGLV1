using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using FluentValidation.Results;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Infrastructure;

namespace NGL.Web.Models.Assessment
{
    public class CreateModelValidator : AbstractValidator<CreateAssessmentModel>
    {
        private readonly IGenericRepository _genericRepository;

        public CreateModelValidator(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;

            RuleFor(m => m.Session).NotEmpty();
            RuleFor(m => m.Section).NotEmpty();
            RuleFor(m => m.AssessmentTitle).NotEmpty().Length(1, 60);
            RuleFor(m => m.QuestionType).NotEmpty();
            RuleFor(m => m.GradeLevel).NotEmpty();
            RuleFor(m => m.AdministeredDate).NotNull();
            RuleFor(m => m.CommonCoreStandard).NotNull();
            RuleFor(m => m.ReportingMethod).NotEmpty();
            RuleFor(m => m.NearMastery).NotEmpty().LessThan(m => m.Mastery);
            RuleFor(m => m.Mastery).NotEmpty().GreaterThan(m => m.NearMastery).LessThanOrEqualTo(100m);
        }

        public override ValidationResult Validate(ValidationContext<CreateAssessmentModel> context)
        {
            var result = base.Validate(context);
            return new ValidationResult(result.Errors.Union(ValidateExistence(context.InstanceToValidate)));
        }

        private IEnumerable<ValidationFailure> ValidateExistence(CreateAssessmentModel createAssessmentModel)
        {
            var section = _genericRepository.Get<Data.Entities.Section>(s => s.SectionIdentity == createAssessmentModel.SectionId);
            
            var assessment = _genericRepository.Get<Data.Entities.Assessment>(a => a.AssessmentTitle == createAssessmentModel.AssessmentTitle);


            if (section == null)
            {
                yield return
                    new ValidationFailure(createAssessmentModel.GetNameFor(s => s.Section),
                        "This section could not be found");
            }

            if (assessment != null)
            {
                yield return new ValidationFailure(createAssessmentModel.GetNameFor(a => a.AssessmentTitle), "This assessment title has already been used");
            }
        }
    }
}