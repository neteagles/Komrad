namespace Frameplate.NHibernate.Conventions
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Inspections;
    using FluentNHibernate.Conventions.Instances;

    public class PluralRelationsConvention : IHasManyConvention, IHasManyToManyConvention
    {
        public void Apply(IOneToManyCollectionInstance instance)
        {
            instance.Access.ReadOnlyPropertyThroughCamelCaseField(CamelCasePrefix.Underscore);
            instance.Cascade.AllDeleteOrphan();            
            if (instance.OtherSide == null)
                instance.Not.Inverse();
            else
                instance.Inverse();
            instance.BatchSize(500);
            instance.AsSet();
            instance.Not.KeyNullable();
            instance.LazyLoad();
        }

        public void Apply(IManyToManyCollectionInstance instance)
        {
            instance.Access.ReadOnlyPropertyThroughCamelCaseField(CamelCasePrefix.Underscore);
            instance.Cascade.SaveUpdate();
            instance.BatchSize(500);
            instance.AsSet();
            instance.LazyLoad();
        }
    }
}