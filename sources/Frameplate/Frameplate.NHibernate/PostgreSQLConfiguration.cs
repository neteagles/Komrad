namespace Frameplate.NHibernate
{
    public class PostgreSQLConfiguration : FluentNHibernate.Cfg.Db.PostgreSQLConfiguration
    {
        public static FluentNHibernate.Cfg.Db.PostgreSQLConfiguration PostgreSQL94
            => new PostgreSQLConfiguration().Dialect<PostgreSQL94Dialect>();
    }
}