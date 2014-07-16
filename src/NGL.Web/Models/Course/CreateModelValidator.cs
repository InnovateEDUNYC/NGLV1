using FluentValidation;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Models.Course
{
    public class CreateModelValidator :AbstractValidator<CreateModel>
    {
        private readonly IGenericRepository _genericRepository;

        public CreateModelValidator(IGenericRepository repo)
        {
            _genericRepository = repo;
            RuleFor(m => m.CourseCode).Must(NotExist).WithMessage("This course already exists.");
        }

        private bool NotExist(string courseCode)
        {
            if (string.IsNullOrEmpty(courseCode)) 
                return true;

            return _genericRepository.Get<Data.Entities.Course>(c => c.CourseCode == courseCode) == null;
        }
    }
}
