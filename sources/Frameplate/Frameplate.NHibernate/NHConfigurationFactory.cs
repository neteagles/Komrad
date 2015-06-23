namespace Frameplate.NHibernate
{
    using System;
    using System.Linq;
    using System.Reflection;
    using FluentNHibernate.Automapping;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using FluentNHibernate.Conventions.Helpers;
    using global::NHibernate.Cfg;
    using global::NHibernate.Context;

    public abstract class NHConfigurationFactoryBase
    {
        private readonly string _connectionStringKey;

        protected readonly Assembly DomainModelAssembly;
        protected readonly Assembly OverridesAssembly;

        protected NHConfigurationFactoryBase(string connectionStringKey)
        {
            _connectionStringKey = connectionStringKey;

            DomainModelAssembly = AppDomain.CurrentDomain.GetAssemblies()
                .FirstOrDefault(x => x.FullName.Contains("Domain.Model"));
            OverridesAssembly = GetType().Assembly;
        }

        public virtual Configuration CreateConfiguration()
        {
            var config = CreatePersistenceConfigurer();

            var persistenceModel = AutoMap
                .Assembly(DomainModelAssembly, new AutomappingConfiguration())
                .UseOverridesFromAssembly(OverridesAssembly)
                .Conventions.AddFromAssemblyOf<NHConfigurationFactoryBase>();

            var autoPersistenceModel = persistenceModel.Conventions
                .Setup(z => z.Add(AutoImport.Never()));

            var fluentConfiguration = Fluently.Configure()
                .CurrentSessionContext<ThreadStaticSessionContext>()
                .Database(config)
                .Mappings(x => x.AutoMappings.Add(autoPersistenceModel));

            return fluentConfiguration
                .BuildConfiguration();
        }

        private IPersistenceConfigurer CreatePersistenceConfigurer
            ()
        {
            return PostgreSQLConfiguration.PostgreSQL94
                .ConnectionString(x => x.FromConnectionStringWithKey(_connectionStringKey))
                .UseReflectionOptimizer()
                .AdoNetBatchSize(100);
        }
    }
}