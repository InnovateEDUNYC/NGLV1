﻿using System;
using System.Linq.Expressions;
using FluentValidation;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Models.Location
{
    public class CreateModelValidator : AbstractValidator<CreateModel>
    {
        public CreateModelValidator(IGenericRepository genericRepository)
        {
            var existenceValidator = new ExistenceValidator<Data.Entities.Location>(genericRepository);
            Expression<Func<Data.Entities.Location, bool>> expression;

            RuleFor(model => model.ClassroomIdentificationCode).Must(classroomIdentificationCode =>
            {
                expression = entity => entity.ClassroomIdentificationCode == classroomIdentificationCode;
                return existenceValidator.Validate(classroomIdentificationCode, expression);
            }).WithMessage("This classroom location already exists.");
        }
    }
}