using NGL.Web.Data.Entities;

namespace NGL.Web.Data.Repositories
{
    public interface IParentRepository
    {
        Parent GetByUSI(int parentUsi);
    }
}