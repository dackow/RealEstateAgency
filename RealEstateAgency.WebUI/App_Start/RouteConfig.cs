using RealEstateAgency.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RealEstateAgency.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                 name: null,
                url: "Offer",
                defaults: new { controller = "Offer", action = "List"}
            );

            routes.MapRoute(
                 name: null,
                url: "Admin",
                defaults: new { controller = "Admin", action = "Index" }
            );



            routes.MapRoute(
                name: null,
                url: "",
                defaults: new { controller = "Offer", action = "List", category = (string)null, page = 1 }
            );

            routes.MapRoute(
                name: null,
                url: "Contact/{offerId}",
                defaults: new { controller = "Offer", action = "Contact", offerId = (string)null },
                constraints: new { offerId = @"\d+" }
            );


            routes.MapRoute(
                name: null,
                url: "Page{page}",
                defaults: new { controller = "Offer", action = "List", category = (string)null },
                constraints: new { page = @"\d+" }
            );

            routes.MapRoute(
                name: null,
                url: "{category}",
                defaults: new { controller = "Offer", action = "List", page = 1}               
            );

            routes.MapRoute(
                name: null,
                url: "{category}/Page{page}",
               defaults: new { controller = "Offer", action = "List" },
               constraints: new { page = @"\d+" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Offer", action = "List", searchCriteria = new SearchCriteria() }
            );
        }
    }
}
