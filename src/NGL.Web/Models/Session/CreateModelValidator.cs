using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentValidation;
using FluentValidation.Results;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Queries;
using NGL.Web.Infrastructure;

namespace NGL.Web.Models.Session
{
    public class CreateModelValidator : AbstractValidator<CreateModel>
    {
        private readonly IGenericRepository _genericRepository;

        public CreateModelValidator()
        {
            _genericRepository = DependencyResolver.Current.GetService<IGenericRepository>();
        }

        public override ValidationResult Validate(ValidationContext<CreateModel> context)
        {
            var result = base.Validate(context);
            return new ValidationResult(result.Errors.Union(ValidateExistence(context.InstanceToValidate)));
        }

        private IEnumerable<ValidationFailure> ValidateExistence(CreateModel createModel)
        {
            if (createModel.Term == null) yield break;

            var query = new SessionByTermTypeAndSchoolYearQuery(
                (int) createModel.Term,
                (short) createModel.SchoolYear);

            if (_genericRepository.Get(query) != null)
            {
                yield return new ValidationFailure(createModel.GetNameFor(c => c.Term), " ");
                yield return new ValidationFailure(createModel.GetNameFor(c => c.SchoolYear), "This session already exists!");
            }
        }
    }
}