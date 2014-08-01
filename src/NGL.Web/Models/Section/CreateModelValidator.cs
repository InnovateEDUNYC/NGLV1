using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using FluentValidation.Results;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Queries;
using NGL.Web.Infrastructure;

namespace NGL.Web.Models.Section
{

    public class CreateModelValidator : AbstractValidator<CreateModel>
    {
        private readonly IGenericRepository _genericRepository;

        public CreateModelValidator(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;

            RuleFor(model => model.SchoolYear).NotEmpty();
            RuleFor(model => model.Term).NotEmpty();
            RuleFor(model => model.Period).NotEmpty();
            RuleFor(model => model.Classroom).NotEmpty();
            RuleFor(model => model.Course).NotEmpty();
            RuleFor(model => model.UniqueSectionCode).NotEmpty().Length(1, 255);
            RuleFor(model => model.SequenceOfCourse).NotEmpty();
        }

        public override ValidationResult Validate(ValidationContext<CreateModel> context)
        {
            var result = base.Validate(context);
            return new ValidationResult(result.Errors.Union(ValidateExistence(context.InstanceToValidate)));
        }

        private IEnumerable<ValidationFailure> ValidateExistence(CreateModel createModel)
        {
            if (createModel.Period == null || createModel.Classroom == null ||
                createModel.Course == null) yield break;

            var query = new SectionByPrimaryKeysQuery(
                (short) createModel.SchoolYear,
                (int) createModel.Term,
                createModel.Period,
                createModel.Classroom,
                createModel.Course
                );

            if (_genericRepository.Get(query) != null)
            {
                yield return new ValidationFailure(createModel.GetNameFor(s => s.SchoolYear), " ");
                yield return new ValidationFailure(createModel.GetNameFor(s => s.Term), " ");
                yield return new ValidationFailure(createModel.GetNameFor(s => s.Period), " ");
                yield return new ValidationFailure(createModel.GetNameFor(s => s.Classroom), " ");
                yield return new ValidationFailure(createModel.GetNameFor(s => s.Course), "This section already exists.");
                    
            }
        }
    }
}