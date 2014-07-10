using System.Collections.Generic;
using FluentValidation.Results;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Models
{
    public class ExistenceValidator<T>
        where T:class 
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IQuery<T> _query;
        private readonly IDictionary<string, string> _errors;

        public ExistenceValidator(IGenericRepository genericRepository, IQuery<T> query, IDictionary<string, string> errors)
        {
            _genericRepository = genericRepository;
            _query = query;
            _errors = errors;
        }

        public IEnumerable<ValidationFailure> Validate()
        {
            var existingEntity = _genericRepository.Get(_query);

            if (existingEntity != null)
            {
                foreach (var error in _errors)
                {
                    yield return new ValidationFailure(error.Key, error.Value);
                }
            }
        }
    }
}