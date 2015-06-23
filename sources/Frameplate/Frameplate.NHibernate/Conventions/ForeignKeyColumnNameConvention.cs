namespace Frameplate.NHibernate.Conventions
{
    using System;
    using FluentNHibernate;
    using FluentNHibernate.Conventions;
    using Utilities;

    public class ForeignKeyColumnNameConvention : ForeignKeyConvention
    {
        protected override string GetKeyName(Member member, Type type)
        {
            return string.Format("{0}_id", member == null 
                ? NameConventions.ReplaceCamelCaseWithUnderscore(type.Name)
                : NameConventions.ReplaceCamelCaseWithUnderscore(member.Name));
        }
    }
}