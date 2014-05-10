using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace makitCommerce.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Product",
                url: "p/{id}/{slug}",
                defaults: new { controller = "Product", action = "Display", id = UrlParameter.Optional, slug = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Category",
                url: "c/{id}/{slug}",
                defaults: new { controller = "Category", action = "Display", id = UrlParameter.Optional, slug = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "CustomPage", action = "Render", id = UrlParameter.Optional }
            );
        }
    }
}