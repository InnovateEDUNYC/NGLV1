using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Models.Location
{
    public class CreateModelValidator : AbstractValidator<CreateModel>
    {
        private readonly IGenericRepository _genericRepository;

        public CreateModelValidator(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
            RuleFor(m => m.ClassroomIdentificationCode).Must(NotExist).WithMessage("This classroom location already exists.");
        }

        private bool NotExist(string classroomIdentificationCode)
        {
            if (string.IsNullOrEmpty(classroomIdentificationCode))
                return true;

            return
                _genericRepository.Get<Data.Entities.Location>(
                    l => l.ClassroomIdentificationCode == classroomIdentificationCode) == null;
        }
    }
}