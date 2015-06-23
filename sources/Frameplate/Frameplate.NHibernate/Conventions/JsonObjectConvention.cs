namespace Frameplate.NHibernate.Conventions
{
    using System.Linq;
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.AcceptanceCriteria;
    using FluentNHibernate.Conventions.Inspections;
    using FluentNHibernate.Conventions.Instances;
    using UserTypes;

    public class JsonObjectConvention : IUserTypeConvention
    {
        public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
            criteria.Expect(x => x.Property.PropertyType.IsGenericType &&
                                 x.Property.PropertyType.GetGenericTypeDefinition() == typeof (JsonObject<>));
        }

        public void Apply(IPropertyInstance instance)
        {
            var jsonObjectTypeArgument = instance.Property.PropertyType.GetGenericArguments().First();
            var jsonObjectUserType = typeof (JsonObjectUserType<>).MakeGenericType(jsonObjectTypeArgument);

            instance.CustomType(jsonObjectUserType);
            instance.LazyLoad();
        }
    }
}