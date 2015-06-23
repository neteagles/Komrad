namespace Frameplate.NHibernate
{
    using System.Data;
    using Frameplate.Domain;
    using global::NHibernate;
    using global::NHibernate.Context;
    using Ksnsi.Domain.DataAccess;

    public class NHUnitOfWork : IUnitOfWork
    {
        private readonly ISession _session;
        private ITransaction _transaction;
        private readonly bool _isNested;

        public NHUnitOfWork(ISessionProvider sessionProvider, bool isNested, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            _isNested = isNested;            

            if (_isNested)
            {
                _session = sessionProvider.Session;
            }
            else
            {
                _session = sessionProvider.RegenerateSession();
                _transaction = _session.BeginTransaction(isolationLevel);
            }

            CurrentSessionContext.Bind(_session);
        }

        public void Dispose()
        {
            Finished = true;

            if (_isNested || Finished)
                return;

            if (!_transaction.WasCommitted && !_transaction.WasRolledBack)
                _transaction.Rollback();
            _transaction.Dispose();
            _transaction = null;

            CurrentSessionContext.Unbind(_session.SessionFactory);
            _session.Dispose();
        }

        public void Commit()
        {
            if (_isNested)
                return;

            _transaction.Commit();
        }

        public void Rollback()
        {
            if (_isNested)
                return;

            _transaction.Rollback();
        }

        public bool Finished { get; private set; }

        public void Save<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            _session.Save(entity);
        }

        public void Update<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            _session.Update(entity);
        }

        public void Delete<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            _session.Delete(entity);
        }
    }
}