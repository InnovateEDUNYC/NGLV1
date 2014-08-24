namespace NGL.Web.Data.Infrastructure
{
    public class RepositoryBase : IRepositoryBase
    {        
        protected readonly INglDbContext DbContext;

        public RepositoryBase(INglDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Save()
        {
            DbContext.Save();
        }
    }
}