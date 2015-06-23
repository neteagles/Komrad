namespace Frameplate.NHibernate.Conventions
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;
    using Utilities;

    public class ColumnNameConvention : IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            instance.Column(NameConventions.ReplaceCamelCaseWithUnderscore(instance.Name));
        }
    }
}