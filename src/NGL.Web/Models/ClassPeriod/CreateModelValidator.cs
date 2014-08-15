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

            RuleFor(model => model.ClassPeriodName).Must(classPeriodName =>
            {
                Expression<Func<Data.Entities.ClassPeriod, bool>> expression = entity => entity.ClassPeriodName == classPeriodName;
                return repositoryReader.DoesRepositoryReturnNullFor(classPeriodName, expression);
            }).WithMessage("This period name already exists.");
        }

    }
}