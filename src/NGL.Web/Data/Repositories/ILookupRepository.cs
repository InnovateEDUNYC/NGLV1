using System.Collections.Generic;

namespace NGL.Web.Data.Repositories
{
    public interface ILookupRepository
    {
        IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class;
    }
}