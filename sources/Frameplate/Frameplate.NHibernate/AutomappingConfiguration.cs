namespace Frameplate.NHibernate
{
    using System;
    using Domain;
    using FluentNHibernate;
    using FluentNHibernate.Automapping;
    using Utilities;

    public class AutomappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool AbstractClassIsLayerSupertype(Type type)
        {
            return true;
        }

        public override bool IsComponent(Type type)
        {
            return typeof(IEntityComponent).IsAssignableFrom(type);
        }

        public override bool IsDiscriminated(Type type)
        {
            return true;
        }

        public override bool ShouldMap(Type type)
        {
            return typeof(IEntity).IsAssignableFrom(type);
        }

        public override string GetComponentColumnPrefix(Member member)
        {
            return $"{NameConventions.ReplaceCamelCaseWithUnderscore(member.Name)}_";
        }
    }
}