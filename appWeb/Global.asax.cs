using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace appWeb
{
    public class CustomViewEngine : RazorViewEngine
    {
        public CustomViewEngine()
        {
            ViewLocationFormats = new[] {
                "~/1.UserInterface/Web/Views/{1}/{0}.cshtml",
                "~/1.UserInterface/Web/Views/{1}/{0}.vbhtml",
                "~/1.UserInterface/Web/Views/Shared/{0}.cshtml",
                "~/1.UserInterface/Web/Views/Shared/{0}.vbhtml"
            };

            MasterLocationFormats = new[] {
                "~/1.UserInterface/Web/Views/{1}/{0}.cshtml",
                "~/1.UserInterface/Web/Views/{1}/{0}.vbhtml",
                "~/1.UserInterface/Web/Views/Shared/{0}.cshtml",
                "~/1.UserInterface/Web/Views/Shared/{0}.vbhtml"
            };

            PartialViewLocationFormats = new[] {
                "~/1.UserInterface/Web/Views/{1}/{0}.cshtml",
                "~/1.UserInterface/Web/Views/{1}/{0}.vbhtml",
                "~/1.UserInterface/Web/Views/Shared/{0}.cshtml",
                "~/1.UserInterface/Web/Views/Shared/{0}.vbhtml"
            };
        }
    }

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Configurar el ViewEngine personalizado
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new CustomViewEngine());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
