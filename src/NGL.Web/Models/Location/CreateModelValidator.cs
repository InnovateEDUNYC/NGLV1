using System;
using System.Linq.Expressions;
using FluentValidation;

namespace NGL.Web.Models.Location
{
    public class CreateModelValidator : AbstractValidator<CreateModel>
    {
        public CreateModelValidator(RepositoryReader<Data.Entities.Location> repositoryReader)
        {
            RuleFor(model => model.ClassroomIdentificationCode).Must(classroomIdentificationCode =>
            {
                Expression<Func<Data.Entities.Location, bool>> expression = entity => entity.ClassroomIdentificationCode == classroomIdentificationCode;
                return repositoryReader.DoesRepositoryReturnNullFor(classroomIdentificationCode, expression);
            }).WithMessage("This classroom location already exists.");
        }
    }
}