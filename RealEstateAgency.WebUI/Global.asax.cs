using RealEstateAgency.Domain.Entities;
using RealEstateAgency.WebUI.Binders;
using RealEstateAgency.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RealEstateAgency.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ModelBinders.Binders.Add(typeof(SearchCriteria), new SearchCriteriaModelBinder());
            //ModelBinders.Binders.Add(typeof(Offer), new OfferModelBinder())/*;*/
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
