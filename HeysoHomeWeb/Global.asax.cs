using Spring.Context.Support;
using Spring.Data.Config;
using Spring.Objects.Factory.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HeysoHomeWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);

            NamespaceParserRegistry.RegisterParser(typeof(DatabaseNamespaceParser));
            var ctx = new XmlApplicationContext("assembly://HeysoHomeWeb/HeysoHomeWeb/dbContextConfig.xml");

            Application["appContext"] = ctx;


        }
    }
}
