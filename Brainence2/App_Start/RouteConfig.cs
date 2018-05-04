using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Brainence2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "Home",
               url: "Home/Index",
               defaults: new {
                   controller = "Home", action = "Index" }
           );
           routes.MapRoute(
              name: "",
              url: "Home/ShowSavedSentences",
              defaults: new
              {
                  controller = "Home",
                  action = "ShowSavedSentences"
              }
          ); 
                routes.MapRoute(
              name: "",
              url: "Home/LoadFile",
              defaults: new
              {
                  controller = "Home",
                  action = "LoadFile"
              }
          );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
        }
    }
}
