using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
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

            RuleFor(model => model.Session).NotEmpty();
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
            foreach (var validationFailure in CheckForNulls(createModel)) { yield return validationFailure; }

            var query = new SectionByPrimaryKeysQuery(
                createModel.SchoolYear,
                createModel.Term,
                createModel.Period,
                createModel.Classroom,
                createModel.Course
                );

            if (_genericRepository.Get(query) != null)
            {
                yield return new ValidationFailure(createModel.GetNameFor(s => s.Session), " ");
                yield return new ValidationFailure(createModel.GetNameFor(s => s.Period), " ");
                yield return new ValidationFailure(createModel.GetNameFor(s => s.Classroom), " ");
                yield return new ValidationFailure(createModel.GetNameFor(s => s.Course), "This section already exists");
            }
        }

        private IEnumerable<ValidationFailure> CheckForNulls(CreateModel createModel)
        {
            var period =
                _genericRepository.Get<Data.Entities.ClassPeriod>(cp => cp.ClassPeriodName == createModel.Period);

            var classroom =
                _genericRepository.Get<Data.Entities.Location>(l => l.ClassroomIdentificationCode == createModel.Classroom);
            
            var session =
                _genericRepository.Get<Data.Entities.Session>(
                    s => s.SchoolYear == createModel.SchoolYear && s.TermTypeId == createModel.Term);
            
            var course = _genericRepository.Get<Data.Entities.Course>(c => c.CourseCode == createModel.Course);


            if (period == null)
            {
                yield return new ValidationFailure(createModel.GetNameFor(s => s.Period), "This period could not be found");
            }

            if (classroom == null)
            {
                yield return new ValidationFailure(createModel.GetNameFor(s => s.Classroom), "This classroom could not be found");
            }

            if (session == null)
            {
                yield return new ValidationFailure(createModel.GetNameFor(s => s.Session), "This session could not be found");
            }

            if (course == null)
            {
                yield return new ValidationFailure(createModel.GetNameFor(s => s.Course), "This course could not be found");
            }
        }
    }
}