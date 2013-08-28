using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NSA.Domain;
using NSA.Persistence;
using NSA.Services.Controllers;
using NailsFramework.Config;
using NailsFramework.IoC;
using NailsFramework.Logging;
using NailsFramework.Persistence;
using NailsFramework.UserInterface;

namespace NSA.Services
{
    public class WebApiApplication : NailsMvcApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected override void ConfigureNails(INailsConfigurator nails)
        {
            nails.InspectAssemblyOf<Client>()
                .InspectAssemblyOf<HomeController>()
                .IoC.Container<Unity>()
                .Persistence.DataMapper<EntityFramework>(x => x.Configure<NSAContext>())
                .Logging.Logger<Log4net>()
                .Initialize();
        }
    }
}