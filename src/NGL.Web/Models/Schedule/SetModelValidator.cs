using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using FluentValidation.Results;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Queries;
using NGL.Web.Infrastructure;
using NGL.Web.Models.Section;

namespace NGL.Web.Models.Schedule
{
    public class SetModelValidator: AbstractValidator<SetModel>
    {
        private readonly IGenericRepository _genericRepository;

        public SetModelValidator(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;

            RuleFor(model => model.BeginDate).NotEmpty();
            RuleFor(model => model.EndDate).NotEmpty();
            RuleFor(model => model.Session).NotEmpty();
            RuleFor(model => model.StudentUsi).NotEmpty();
            RuleFor(model => model.SectionId).NotEmpty();
        }

        public override ValidationResult Validate(ValidationContext<SetModel> context)
        {
            var result = base.Validate(context);
            return new ValidationResult(result.Errors.Union(ValidateExistence(context.InstanceToValidate)));
        }

        private IEnumerable<ValidationFailure> ValidateExistence(SetModel setModel)
        {
            var section = _genericRepository.Get<Data.Entities.Section>(s => s.SectionIdentity == setModel.SectionId);
            if (section == null)
            {
                yield return
                    new ValidationFailure(setModel.GetNameFor(s => s.ErrorMessage),
                        "This section could not be found in the database");
            }
            else
            {
                var query = new StudentSectionAssociationByPrimaryKeysQuery(
                    setModel.StudentUsi,
                    setModel.BeginDate,
                    section.SchoolYear,
                    section.TermTypeId,
                    section.LocalCourseCode,
                    section.ClassPeriodName,
                    section.ClassroomIdentificationCode
                    );

                if (_genericRepository.Get(query) != null)
                {
                    yield return
                        new ValidationFailure(setModel.GetNameFor(s => s.ErrorMessage),
                            "This student has already been scheduled for this section for this begin date.");
                }
            }
        }
    }
}