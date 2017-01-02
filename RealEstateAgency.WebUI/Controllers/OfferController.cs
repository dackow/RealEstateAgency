using RealEstateAgency.Domain.Abstract;
using RealEstateAgency.WebUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstateAgency.WebUI.Controllers
{
    public class OfferController : Controller
    {
        private readonly IOfferRepository repository;
        private readonly WebConfigOptionsHelper optionsHelper = new WebConfigOptionsHelper();
        public int pageSize = 4;
        public OfferController()
        {
            pageSize = Convert.ToInt32(optionsHelper.GetOption("DefaultPageSize"));
        }

        public OfferController(IOfferRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(int page = 1)
        {
            return View(repository.Offers.OrderBy(o=>o.Id).Skip((page-1)*pageSize).Take(pageSize));
        }
    }
}