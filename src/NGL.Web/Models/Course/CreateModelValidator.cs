using System;
using System.Linq.Expressions;
using FluentValidation;

namespace NGL.Web.Models.Course
{
    public class CreateModelValidator : AbstractValidator<CreateModel>
    {
        public CreateModelValidator(IRepositoryReader<Data.Entities.Course> repositoryReader)
        {
            RuleFor(model => model.ParentCourseId).NotEmpty();
            RuleFor(model => model.CourseCode).NotEmpty().Length(1, 60);
            RuleFor(model => model.CourseTitle).NotEmpty().Length(1, 60);
            RuleFor(model => model.NumberOfParts).NotEmpty();
            RuleFor(model => model.AcademicSubject).NotEmpty();
            RuleFor(model => model.CourseDescription).Length(0, 20);

            RuleFor(model => model.CourseCode).Must(courseCode =>
            {
                Expression<Func<Data.Entities.Course, bool>> expression = entity => entity.CourseCode == courseCode;
                return repositoryReader.DoesRepositoryReturnNullFor(courseCode, expression);
            }).WithMessage("This course already exists.");
        }

    }
}
