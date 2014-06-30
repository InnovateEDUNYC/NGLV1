namespace NGL.Web.Data.Infrastructure
{
    public interface IEntity
    {
    }

    public interface IEntityWithId
    {
        int Id { get; }         
    }
}