﻿using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NSA.Client.Web.App_Start;
using NSA.Client.Web.Controllers;
using NSA.Persistence;
using NSA.Support.Adapter;
using NailsFramework.Config;
using NailsFramework.IoC;
using NailsFramework.Logging;
using NailsFramework.Persistence;
using NailsFramework.UserInterface;

namespace NSA.Client.Web
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
            nails.InspectAssemblyOf<Domain.Client>()
                .InspectAssemblyOf<HomeController>()
                .InspectAssemblyOf<AdapterManager>()
                .IoC.Container<Unity>()
                .Persistence.DataMapper<EntityFramework>(x => x.Configure<NSAContext>())
                .Logging.Logger<Log4net>()
                .Initialize();
        }
    }
}