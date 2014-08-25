using System;
using System.Linq.Expressions;
using FluentValidation;

namespace NGL.Web.Models.ClassPeriod
{
    public class CreateModelValidator : AbstractValidator<CreateModel>
    {
        public CreateModelValidator(IRepositoryReader<Data.Entities.ClassPeriod> repositoryReader)
        {
            RuleFor(model => model.ClassPeriodName).Must(classPeriodName =>
            {
                Expression<Func<Data.Entities.ClassPeriod, bool>> expression = entity => entity.ClassPeriodName == classPeriodName;
                return repositoryReader.DoesRepositoryReturnNullFor(classPeriodName, expression);
            }).WithMessage("This period name already exists.");
        }

    }
}