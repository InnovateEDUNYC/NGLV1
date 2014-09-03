namespace NGL.Web.Data.Infrastructure
{
    public class RepositoryBase : IRepositoryBase
    {        
        protected readonly INglDbContext DbContext;
        protected const int ConstraintExceptionNumber = 547;

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