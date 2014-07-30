using System;
using System.Linq.Expressions;
using FluentValidation;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Models.Section
{
    public class CreateModelValidator : AbstractValidator<CreateModel>
    {

        public CreateModelValidator(IGenericRepository genericRepository)
        {
            var repositoryReader = new RepositoryReader<Data.Entities.Section>(genericRepository);
            Expression<Func<Data.Entities.Section, bool>> expression;

            
        }
    }
}