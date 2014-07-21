using System;
using System.Linq.Expressions;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Models
{
    public class RepositoryReader<T>
        where T:class
    {
        private readonly IGenericRepository _genericRepository;

        public RepositoryReader(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public bool DoesRepositoryReturnNullFor(string primaryKey, Expression<Func<T, bool>> expression)
        {
            return string.IsNullOrEmpty(primaryKey) || _genericRepository.Get(expression) == null;
        }
    }
}