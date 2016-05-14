using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BIG_Warrior_Software_Official_Webpage
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" },
                namespaces: new string[] { "BIG_Warrior_Software_Official_Webpage.Controllers" }
            );
            routes.MapRoute(
                name: "BlogIndex",
                url: "{controller}/{action}",
                defaults: new { controller = "Blog", action = "Index" },
                namespaces: new string[] { "BIG_Warrior_Software_Official_Webpage.Controllers" }
            );

            routes.MapRoute(
                name: "BlogTagName",
                url: "Blog/TagName/{tag}",
                defaults: new { controller = "Blog", action = "TagName", tag = UrlParameter.Optional },
                namespaces: new string[] { "BIG_Warrior_Software_Official_Webpage.Controllers" }
                );
            routes.MapRoute(
                name: "BlogTagNamePage",
                url: "Blog/TagName/{tag}/{page}",
                defaults: new { controller = "Blog", action = "TagName", tag = UrlParameter.Optional, page = UrlParameter.Optional },
                namespaces: new string[] { "BIG_Warrior_Software_Official_Webpage.Controllers" }
            );
            routes.MapRoute(
                name: "BlogGetUrl",
                url: "Blog/GetUrl/{url}",
                defaults: new { controller = "Blog", action = "GetUrl", url = UrlParameter.Optional },
                namespaces: new string[] { "BIG_Warrior_Software_Official_Webpage.Controllers" }
                );
            routes.MapRoute(
                name: "BlogPage",
                url: "Blog/Page/{page}",
                defaults: new { controller = "Blog", action = "Page", page = UrlParameter.Optional },
                namespaces: new string[] { "BIG_Warrior_Software_Official_Webpage.Controllers" }
                );

        }
    }
}
