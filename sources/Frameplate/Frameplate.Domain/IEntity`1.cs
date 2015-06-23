namespace Frameplate.Domain
{
    public interface IEntity<out TId> : IEntity
        where TId : struct
    {
        TId Id { get; } 
    }
}