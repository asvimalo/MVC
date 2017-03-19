using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Security.Claims;
using System.Web.Helpers;
using Lab_1.App_Start;
using System.Web.Optimization;

namespace Lab_1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;


        }
        protected void Application_End()
        { }
        protected void Session_Start()
        { }
        protected void Session_End()
        { }
        protected void Application_Error()
        { }
    }
}
