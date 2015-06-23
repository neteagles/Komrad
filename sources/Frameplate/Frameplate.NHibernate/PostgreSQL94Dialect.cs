namespace Frameplate.NHibernate
{
    using System.Data;
    using global::NHibernate.Dialect;

    public class PostgreSQL94Dialect : PostgreSQL82Dialect
    {
        public PostgreSQL94Dialect()
        {
            RegisterColumnType(DbType.Object, "json");
        }
    }
}