using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using FluentValidation.Results;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Infrastructure;

namespace NGL.Web.Models.Attendance
{
    public class TakeAttendanceModelValidator : AbstractValidator<TakeAttendanceModel>
    {
        private readonly IGenericRepository _genericRepository;

        public TakeAttendanceModelValidator(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;

            RuleFor(m => m.Session).NotEmpty();
            RuleFor(m => m.Section).NotEmpty();
            RuleFor(m => m.Date).NotEmpty();
        }

        public override ValidationResult Validate(ValidationContext<TakeAttendanceModel> context)
        {
            var result = base.Validate(context);
            return new ValidationResult(result.Errors.Union(ValidateExistence(context.InstanceToValidate)));
        }

        private IEnumerable<ValidationFailure> ValidateExistence(TakeAttendanceModel takeAttendanceModel)
        {
            var session =
                _genericRepository.Get<Data.Entities.Session>(s => s.SessionIdentity == takeAttendanceModel.SessionId);
            var section = _genericRepository.Get<Data.Entities.Section>(s => s.SectionIdentity == takeAttendanceModel.SectionId);

            if (section == null)
            {
                yield return
                    new ValidationFailure(takeAttendanceModel.GetNameFor(s => s.Section),
                        "This section could not be found");
            }

            if (session == null)
            {
                yield return
                    new ValidationFailure(takeAttendanceModel.GetNameFor(s => s.Session),
                        "This session could not be found");
            }
        }
    }
}