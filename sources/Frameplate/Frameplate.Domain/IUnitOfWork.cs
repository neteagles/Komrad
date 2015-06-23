namespace Frameplate.Domain
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        bool Finished { get; }

        void Save<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        void Update<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        void Delete<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        void Commit();
        void Rollback();
    }
}