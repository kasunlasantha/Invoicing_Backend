using AutoMapper;
using SLTInvoicingBackend.Core;
using SLTInvoicingBackend.WebAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SLTInvoicingBackend.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //        GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
            //.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //        GlobalConfiguration.Configuration.Formatters
            //            .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

            HttpConfiguration config = GlobalConfiguration.Configuration;

            config.Formatters.JsonFormatter
                        .SerializerSettings
                        .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            log4net.Config.XmlConfigurator.Configure();
        }

        
    }
}
