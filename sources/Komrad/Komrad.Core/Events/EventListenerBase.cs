namespace Komrad.Core.Events
{
    public abstract class EventListenerBase
    {
        internal string Namespace { get; }

        protected EventListenerBase(string eventNamespace)
        {
            Namespace = eventNamespace;
        }
    }
}