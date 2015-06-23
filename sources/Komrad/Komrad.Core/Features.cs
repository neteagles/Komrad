namespace Komrad.Core
{
    using System.Collections.Generic;
    using System.Runtime.Remoting.Messaging;
    using System.Web;

    public static class Features
    {
        public static IFeaturesRegistration ForApplication(HttpApplication application)
        {
            return new FeaturesRegistration(application);
        }
    }

    public interface IFeaturesRegistration
    {
        IRegisteredFeature Register<TFeature>()
            where TFeature : class, IFeature;
    }

    public interface IRegisteredFeature
    {
        IFeaturesRegistration WithDefaultConfiguration();
        IFeaturesRegistration AutoConfigured();
        IFeaturesRegistration ConfiguredUsing(FeatureConfiguratorCallback configurator);
        IFeaturesRegistration ConfiguredUsing<TConfiguration>(FeatureConfigurator<TConfiguration> configurator)
            where TConfiguration : class, IFeatureConfiguration;
    }

    public delegate void FeatureConfiguratorCallback(IFeatureConfiguration configuration);

    public interface IFeature
    {
        IFeatureConfiguration Configuration { get; }
        FeatureConfigurator DefaultConfigurator { get; }
        IEnumerable<string> Emits { get; }
        IEnumerable<string> Listens { get; set; }
    }

    internal class FeaturesRegistration : IFeaturesRegistration
    {
        private readonly HttpApplication _application;

        public FeaturesRegistration(HttpApplication application)
        {
            _application = application;
        }

        public IRegisteredFeature Register<TFeature>()
            where TFeature : class, IFeature
        {
            throw new System.NotImplementedException();
        }
    }
}