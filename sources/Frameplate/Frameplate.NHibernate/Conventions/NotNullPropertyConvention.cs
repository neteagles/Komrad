namespace Frameplate.NHibernate.Conventions
{
    using System.Linq;
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Inspections;
    using FluentNHibernate.Conventions.Instances;

    public class NotNullPropertyConvention : IPropertyConvention, IReferenceConvention
    {
        private static bool IsNotNull(IExposedThroughPropertyInspector instance)
        {
            //return instance.Property.MemberInfo.GetCustomAttributes(typeof(NotNullAttribute), false).Any();
            return false;
        }

        public void Apply(IPropertyInstance instance)
        {
            if (!IsNotNull(instance))
                return;
            instance.Not.Nullable();
        }

        public void Apply(IManyToOneInstance instance)
        {
            if (!IsNotNull(instance))
                return;
            instance.Not.Nullable();
            instance.NotFound.Exception();
        }
    }
}