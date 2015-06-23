namespace Frameplate.NHibernate.Conventions
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;

    public class SingularRelationsConvention : IReferenceConvention, IHasOneConvention
    {
        public void Apply(IManyToOneInstance instance)
        {
            instance.LazyLoad();
            instance.NotFound.Ignore();
        }

        public void Apply(IOneToOneInstance instance)
        {
            instance.LazyLoad();
        }
    }
}