using Notes.API.App_Start;
using Notes.API.App_Start.NinjectConfig;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Notes.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public WebApiApplication()
        {
        }

        protected void Application_Start()
        {
            IocConfig.RegisterIoc(GlobalConfiguration.Configuration);

            //GlobalConfiguration.Configure();

            //AreaRegistration.RegisterAllAreas();

            AutoMapperConfig.Register();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            WebApiConfig.Register(GlobalConfiguration.Configuration);

            GlobalConfiguration.Configuration.EnsureInitialized();
        }
    }
}
