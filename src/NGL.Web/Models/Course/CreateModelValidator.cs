using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentValidation;
using FluentValidation.Results;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Infrastructure;

namespace NGL.Web.Models.Course
{
    public class CreateModelValidator :AbstractValidator<CreateModel>
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
            if (createModel.CourseCode == null) yield break;
            
            if (_genericRepository.Get<Data.Entities.Course>(
                c => c.CourseCode == createModel.CourseCode) != null)
            {
                yield return new ValidationFailure(createModel.GetNameFor(c => c.CourseCode), 
                    "This course already exists!");
            }
        }
    }
}