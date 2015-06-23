namespace Komrad.Features.Users
{
    using System.Collections.Generic;
    using Core;

    public class UsersFeature : IFeature
    {
        public UsersFeature()
        {
            Configuration = new Configuration();
        }

        public IFeatureConfiguration Configuration { get; }

        public FeatureConfigurator DefaultConfigurator
            => new DefaultConfigurator();

        public IEnumerable<string> Emits { get; }
        public IEnumerable<string> Listens { get; set; }
    }
}