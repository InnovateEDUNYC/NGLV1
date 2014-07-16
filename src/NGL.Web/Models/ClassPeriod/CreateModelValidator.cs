using System;
using System.Linq.Expressions;
using FluentValidation;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Models.ClassPeriod
{
    public class CreateModelValidator : AbstractValidator<CreateModel>
    {
        public CreateModelValidator(IGenericRepository genericRepository)
        {
            var existenceValidator = new ExistenceValidator<Data.Entities.ClassPeriod>(genericRepository);
            Expression<Func<Data.Entities.ClassPeriod, bool>> expression;

            RuleFor(model => model.ClassPeriodName).Must(classPeriodName =>
            {
                expression = entity => entity.ClassPeriodName == classPeriodName;
                return existenceValidator.Validate(classPeriodName, expression);
            }).WithMessage("This period name already exists.");
        }

    }
}