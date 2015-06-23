namespace Frameplate.NHibernate
{
    using global::NHibernate;
    using Ksnsi.Domain.DataAccess;

    public class NHPerThreadSessionProvider : ISessionProvider
    {
        private readonly ISessionFactory _sessionFactory;

        public NHPerThreadSessionProvider(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public ISession Session { get; private set; }

        public ISession RegenerateSession()
        {
            Session?.Dispose();

            return Session = _sessionFactory.OpenSession();
        }

        public void Dispose()
        {
            Session?.Dispose();
        }
    }
}