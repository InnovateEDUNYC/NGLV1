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
            RuleFor(model => model.ParentCourseId).NotEmpty();
            RuleFor(model => model.CourseCode).NotEmpty().Length(1, 60);
            RuleFor(model => model.CourseTitle).NotEmpty().Length(1, 60);
            RuleFor(model => model.NumberOfParts).NotEmpty();
            RuleFor(model => model.AcademicSubject).NotEmpty();
            RuleFor(model => model.CourseDescription).Length(0, 20);

            var repositoryReader = new RepositoryReader<Data.Entities.Course>(genericRepository);

            RuleFor(model => model.CourseCode).Must(courseCode =>
            {
                Expression<Func<Data.Entities.Course, bool>> expression = entity => entity.CourseCode == courseCode;
                return repositoryReader.DoesRepositoryReturnNullFor(courseCode, expression);
            }).WithMessage("This course already exists.");
        }

    }
}
