namespace Web
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Komrad.Core;
    using Komrad.Features.Users;

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);

            Features.ForApplication(this)
                .Register<UsersFeature>().WithDefaultConfiguration();
        }
    }
}
