namespace Komrad.Core
{
    public abstract class FeatureConfigurator
    {
        public void Configure(IFeatureConfiguration configuration)
        {
            
        }

        protected void Warning(string message)
        {
            
        }

        protected void Error(string message)
        {
            
        }

        protected void Fatal(string message)
        {
            
        }
    }

    public abstract class FeatureConfigurator<TConfiguration> : FeatureConfigurator
        where TConfiguration :class, IFeatureConfiguration
    {
        protected abstract void Configure(TConfiguration configuration);
    }
}