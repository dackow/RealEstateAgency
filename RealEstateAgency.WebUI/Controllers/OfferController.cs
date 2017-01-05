using RealEstateAgency.Domain.Abstract;
using RealEstateAgency.WebUI.Helpers;
using RealEstateAgency.WebUI.Models;
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

        public ViewResult List(string category, int page = 1)
        {
            OfferListViewModel model = new OfferListViewModel
            {
                Offers = repository.Offers.
                                    Where(o=> category == null || o.Category == category).
                                    OrderBy(o => o.Id).
                                    Skip((page - 1) * pageSize).
                                    Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ?  repository.Offers.Count() : repository.Offers.Where(o=> o.Category == category).Count()
                },
                CurrentCategory = category

            };
            return View(model);
        }
    }
}