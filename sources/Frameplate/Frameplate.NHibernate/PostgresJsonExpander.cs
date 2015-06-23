namespace Frameplate.NHibernate
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Domain;
    using global::NHibernate;

    public class PostgresJsonExpander : IJsonExpander
    {
        private readonly ISessionFactory _sessionFactory;

        public PostgresJsonExpander(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public TResult Expand<THost, TResult>(THost host, Expression<Func<THost, JsonObject<TResult>>> jsonObjectAccessor) 
            where THost : class, IEntity 
            where TResult : class
        {
            var jsonObjectPropertyName = Name.Of(jsonObjectAccessor);

            using (var session = _sessionFactory.OpenSession())
            {
                var sqlQuery = $"SELECT sections AS result FROM universities WHERE Id = {host.Id};";
                var result = session.CreateSQLQuery(sqlQuery)
                    .List<string>()
                    .FirstOrDefault();

                return JsonConvert.DeserializeObject<TResult>(result);
            }
        }

        public TResult Expand<THost, TObject, TResult>(THost host,
                                                       Expression<Func<THost, JsonObject<TObject>>> jsonObjectAccessor,
                                                       Expression<Func<TObject, TResult>> resultAccessor) 
            where THost : class, IEntity 
            where TObject : class 
            where TResult : class

        {
            var jsonObjectPropertyName = Name.Of(jsonObjectAccessor);

            var resultSqlPathParts = Name.Of(resultAccessor).Split('.')
                .Select(x => $"->'{x}'");
            var resultSqlPath = string.Join(string.Empty, resultSqlPathParts);

            using (var session = _sessionFactory.OpenSession())
            {
                var sqlQuery = $"SELECT sections{resultSqlPath} AS result FROM universities WHERE Id = {host.Id};";
                var result = session.CreateSQLQuery(sqlQuery)
                    .List<string>()
                    .FirstOrDefault();

                return JsonConvert.DeserializeObject<TResult>(result);
            }
        }
    }
}