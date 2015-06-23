namespace Frameplate.Domain
{
    using System.Linq;

    public interface ILinqProvider
    {
        IQueryable<TEntity> GetQueryable<TEntity>() 
            where TEntity : class, IEntity;
    }
}