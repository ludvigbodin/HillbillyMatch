namespace Datalayer.Repositories
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
