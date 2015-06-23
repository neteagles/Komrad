namespace Frameplate.NHibernate.Conventions
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;

    public class EnumIntConvention : IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            if (instance.Type.IsEnum)
                instance.CustomType<int>();
        }
    }
}