using System;
using System.Linq.Expressions;
using FluentValidation;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Models.Course
{
    public class CreateModelValidator : AbstractValidator<CreateModel>
    {
        public CreateModelValidator(IGenericRepository genericRepository)
        {
            var repositoryReader = new RepositoryReader<Data.Entities.Course>(genericRepository);

            RuleFor(model => model.CourseCode).Must(courseCode =>
            {
                Expression<Func<Data.Entities.Course, bool>> expression = entity => entity.CourseCode == courseCode;
                return repositoryReader.DoesRepositoryReturnNullFor(courseCode, expression);
            }).WithMessage("This course already exists.");
        }

    }
}
