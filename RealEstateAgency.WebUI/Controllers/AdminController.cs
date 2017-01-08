using RealEstateAgency.Domain.Abstract;
using RealEstateAgency.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstateAgency.WebUI.Controllers
{
    public class AdminController : Controller
    {
        IOfferRepository repository;


        public AdminController(IOfferRepository repo)
        {
            repository = repo;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View(repository.Offers);
        }

        public ViewResult Edit(int Id)
        {
            Offer offer = repository.Offers.FirstOrDefault(o => o.Id == Id);
            return View(offer);
        }

        [HttpPost]
        public ActionResult Edit(Offer offer)
        {
            if (ModelState.IsValid)
            {
                repository.SaveOffer(offer);
                TempData["message"] = string.Format("{0} has been saved", offer.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(offer);
            }
        }
    }
}