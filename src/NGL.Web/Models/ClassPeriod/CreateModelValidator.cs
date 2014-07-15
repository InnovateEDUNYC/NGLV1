using FluentValidation;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Models.ClassPeriod
{
    public class CreateModelValidator : AbstractValidator<CreateModel>
    {
        private readonly IGenericRepository _genericRepository;


        public CreateModelValidator(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
            RuleFor(m => m.ClassPeriodName).Must(NotExist).WithMessage("This period name already exists.");
        }

        private bool NotExist(string classPeriodName)
        {
            if (string.IsNullOrEmpty(classPeriodName))
                return true;

            return _genericRepository.Get<Data.Entities.ClassPeriod>(c => c.ClassPeriodName == classPeriodName) == null;
        }
    }
}