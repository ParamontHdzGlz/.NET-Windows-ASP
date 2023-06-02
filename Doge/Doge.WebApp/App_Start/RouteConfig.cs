using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;
using System.Web.Mvc;

namespace Doge.WebApp
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes(); // Enable attribute routing

            // Other custom routes

            routes.MapRoute(
                name: "Orders",
                url: "orders",
                defaults: new { controller = "Orders", action = "Get" }
            );
        }
    }
}
