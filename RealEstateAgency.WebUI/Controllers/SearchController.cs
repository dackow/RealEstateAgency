using RealEstateAgency.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstateAgency.WebUI.Controllers
{
    
    public class SearchController : Controller
    {
        private IOfferRepository repository;
        public SearchController(IOfferRepository repo)
        {
            repository = repo;
        }
        public PartialViewResult SearchCriteria()
        {
            return PartialView();
        }
    }
}