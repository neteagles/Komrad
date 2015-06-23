namespace Ksnsi.Domain.DataAccess
{
    using System;
    using global::NHibernate;

    public interface ISessionProvider : IDisposable
    {
        ISession Session { get; }

        ISession RegenerateSession();
    }
}