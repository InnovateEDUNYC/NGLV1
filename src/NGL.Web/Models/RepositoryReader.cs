using System;
using System.Linq.Expressions;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Models
{
    public class RepositoryReader<T> : IRepositoryReader<T> where T : class
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

        public bool DoesRepositoryReturnNullFor(int? primaryKey, Expression<Func<T, bool>> expression)
        {
            return !primaryKey.HasValue || _genericRepository.Get(expression) == null;
        }
    }

    public interface IRepositoryReader<T> where T : class
    {
        bool DoesRepositoryReturnNullFor(string primaryKey, Expression<Func<T, bool>> expression);

        bool DoesRepositoryReturnNullFor(int? primaryKey, Expression<Func<T, bool>> expression);
    }
}