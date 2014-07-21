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
            var repositoryReader = new RepositoryReader<Data.Entities.ClassPeriod>(genericRepository);
            Expression<Func<Data.Entities.ClassPeriod, bool>> expression;

            RuleFor(model => model.ClassPeriodName).Must(classPeriodName =>
            {
                expression = entity => entity.ClassPeriodName == classPeriodName;
                return repositoryReader.RepositoryReturnsNullFor(classPeriodName, expression);
            }).WithMessage("This period name already exists.");
        }

    }
}