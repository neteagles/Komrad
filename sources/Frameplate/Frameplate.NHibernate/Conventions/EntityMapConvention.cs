namespace Frameplate.NHibernate.Conventions
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;
    using Utilities;

    public class EntityMapConvention : IClassConvention, IJoinedSubclassConvention
    {
        public void Apply(IClassInstance instance)
        {
            var tableName = instance.EntityType.Name.ToPlural();
            instance.Table(NameConventions.ReplaceCamelCaseWithUnderscore(tableName));
            instance.BatchSize(250);
        }

        public void Apply(IJoinedSubclassInstance instance)
        {
            var tableName = instance.EntityType.Name.ToPlural();
            instance.Table(NameConventions.ReplaceCamelCaseWithUnderscore(tableName));
            instance.BatchSize(250);
        }
    }
}