namespace Frameplate.NHibernate.Conventions
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;

	public class PropertyLengthConvention : IPropertyConvention
	{
		public void Apply(IPropertyInstance instance)
		{
			instance.Length(short.MaxValue);
		}
	}
}