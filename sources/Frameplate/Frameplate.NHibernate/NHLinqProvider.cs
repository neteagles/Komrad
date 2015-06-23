namespace Frameplate.NHibernate
{
    using System.Linq;
    using Domain;
    using global::NHibernate.Linq;
    using Ksnsi.Domain.DataAccess;

    public class NHLinqProvider : ILinqProvider
    {
        private readonly ISessionProvider _sessionProvider;

        public NHLinqProvider(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        public IQueryable<TEntity> GetQueryable<TEntity>()
            where TEntity : class, IEntity
        {
            return _sessionProvider.Session.Query<TEntity>();
        }
    }
}