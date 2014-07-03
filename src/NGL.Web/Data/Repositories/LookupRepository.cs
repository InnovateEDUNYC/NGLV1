using System.Collections.Generic;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Data.Repositories
{
    public class LookupRepository : ILookupRepository
    {
        private readonly IGenericRepository _genericRepository;

        public LookupRepository(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public IEnumerable<TEntity> GetAll<TEntity>() 
            where TEntity : class
        {
            return _genericRepository.GetAll<TEntity>();
        }
    }
}