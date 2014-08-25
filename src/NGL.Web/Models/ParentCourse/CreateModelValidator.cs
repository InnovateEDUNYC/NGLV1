using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using FluentValidation;

namespace NGL.Web.Models.ParentCourse
{
    public class CreateModelValidator : AbstractValidator<CreateModel>
    {
        public CreateModelValidator(RepositoryReader<Data.Entities.ParentCourse> repositoryReader)
        {
            RuleFor(model => model.ParentCourseCode).Must(courseCode =>
            {
                Expression<Func<Data.Entities.ParentCourse, bool>> expression = entity => entity.ParentCourseCode == courseCode;
                return repositoryReader.DoesRepositoryReturnNullFor(courseCode, expression);
            }).WithMessage("This parent course already exists."); 
        }

    }
}