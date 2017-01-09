using RealEstateAgency.Domain.Abstract;
using RealEstateAgency.Domain.Entities;
using RealEstateAgency.Domain.Setup;
using RealEstateAgency.WebUI.Helpers;
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
            ViewBag.categories = DropDownListHelper.GenerateDataToDropDown(Setups.GetInstance().CATEGORIES, offer.Category);
            ViewBag.offer_types = DropDownListHelper.GenerateDataToDropDown(Setups.GetInstance().OFFER_TYPES, offer.Offer_Type);
            ViewBag.markets = DropDownListHelper.GenerateDataToDropDown(Setups.GetInstance().MARKETS, offer.Market);
            ViewBag.parcel_types = DropDownListHelper.GenerateDataToDropDown(Setups.GetInstance().PARCEL_TYPES, offer.Parcel_Type);
            ViewBag.garage_construction = DropDownListHelper.GenerateDataToDropDown(Setups.GetInstance().GARAGE_CONSTRUCTIONS, offer.Garage_Construction);
            ViewBag.local_purpose = DropDownListHelper.GenerateDataToDropDown(Setups.GetInstance().LOCAL_PURPOSE, offer.Local_Purpose);
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

        public ViewResult Add()
        {
            Offer offer = new Offer();
            ViewBag.categories = DropDownListHelper.GenerateDataToDropDown(Setups.GetInstance().CATEGORIES, string.Empty);
            ViewBag.offer_types = DropDownListHelper.GenerateDataToDropDown(Setups.GetInstance().OFFER_TYPES, string.Empty);
            ViewBag.markets = DropDownListHelper.GenerateDataToDropDown(Setups.GetInstance().MARKETS, string.Empty);
            ViewBag.parcel_types = DropDownListHelper.GenerateDataToDropDown(Setups.GetInstance().PARCEL_TYPES, string.Empty);
            ViewBag.garage_construction = DropDownListHelper.GenerateDataToDropDown(Setups.GetInstance().GARAGE_CONSTRUCTIONS, string.Empty);
            ViewBag.local_purpose = DropDownListHelper.GenerateDataToDropDown(Setups.GetInstance().LOCAL_PURPOSE, string.Empty);
            return View(offer);
        }

        [HttpPost]
        public ActionResult Add(Offer offer)
        {
            if (ModelState.IsValid)
            {
                repository.SaveOffer(offer);
                TempData["message"] = string.Format("{0} has been saved", offer.Name);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.categories = DropDownListHelper.GenerateDataToDropDown(Setups.GetInstance().CATEGORIES, offer.Category);
                ViewBag.offer_types = DropDownListHelper.GenerateDataToDropDown(Setups.GetInstance().OFFER_TYPES, offer.Offer_Type);
                ViewBag.markets = DropDownListHelper.GenerateDataToDropDown(Setups.GetInstance().MARKETS, offer.Market);
                ViewBag.parcel_types = DropDownListHelper.GenerateDataToDropDown(Setups.GetInstance().PARCEL_TYPES, offer.Parcel_Type);
                ViewBag.garage_construction = DropDownListHelper.GenerateDataToDropDown(Setups.GetInstance().GARAGE_CONSTRUCTIONS, offer.Garage_Construction);
                ViewBag.local_purpose = DropDownListHelper.GenerateDataToDropDown(Setups.GetInstance().LOCAL_PURPOSE, offer.Local_Purpose);
                return View(offer);
            }
        }

    }
}