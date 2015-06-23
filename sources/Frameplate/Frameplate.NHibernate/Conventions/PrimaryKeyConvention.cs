namespace Frameplate.NHibernate.Conventions
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;

    public class PrimaryKeyConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            instance.Column("id");
        }
    }
}