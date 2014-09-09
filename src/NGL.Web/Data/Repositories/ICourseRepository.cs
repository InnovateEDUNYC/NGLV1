namespace NGL.Web.Data.Repositories
{
    public interface ICourseRepository
    {
        void Delete(int id);
        bool HasDependencies(int id);
    }
}
