using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using FluentValidation.Results;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Infrastructure;

namespace NGL.Web.Models.Assessment
{
    public class CreateModelValidator : AbstractValidator<CreateModel>
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
        }

        public override ValidationResult Validate(ValidationContext<CreateModel> context)
        {
            var result = base.Validate(context);
            return new ValidationResult(result.Errors.Union(ValidateExistence(context.InstanceToValidate)));
        }

        private IEnumerable<ValidationFailure> ValidateExistence(CreateModel createModel)
        {
            var section = _genericRepository.Get<Data.Entities.Section>(s => s.SectionIdentity == createModel.SectionId);
            
            var assessment = _genericRepository.Get<Data.Entities.Assessment>(a => a.AssessmentTitle == createModel.AssessmentTitle);


            if (section == null)
            {
                yield return
                    new ValidationFailure(createModel.GetNameFor(s => s.Section),
                        "This section could not be found");
            }


            if (assessment != null)
            {
                yield return new ValidationFailure(createModel.GetNameFor(a => a.AssessmentTitle), "This assessment title has already been used");
            }
        }
    }
}