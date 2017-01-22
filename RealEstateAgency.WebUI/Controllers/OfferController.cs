using RealEstateAgency.Domain.Abstract;
using RealEstateAgency.Domain.Entities;
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
                
        public PartialViewResult SearchCriteria(SearchCriteria criteria)
        {
           return PartialView();
        }

        public ViewResult List(SearchCriteria searchCriteria, int page = 1)
        {
            var result = repository.Offers.AsQueryable();

            #region Search Criteria
            if (!string.IsNullOrEmpty(searchCriteria.category))
            {
                result = result.Where(o => o.Category == searchCriteria.category);

                if (!string.IsNullOrEmpty(searchCriteria.location))
                {
                    result = result.Where(o => o.Location.ToUpper() == searchCriteria.location.ToUpper());
                }
                if (searchCriteria.price_max != null)
                {
                    result = result.Where(o => o.Price <= searchCriteria.price_max);
                }
                if (searchCriteria.price_min != null)
                {
                    result = result.Where(o => o.Price >= searchCriteria.price_min);
                }

                switch (searchCriteria.category)
                {
                    case "M":
                        if (searchCriteria.m_area_max != null)
                        {
                            result = result.Where(o => o.Area <= searchCriteria.m_area_max);
                        }
                        if (searchCriteria.m_area_min != null)
                        {
                            result = result.Where(o => o.Area >= searchCriteria.m_area_min);
                        }
                        if (!string.IsNullOrEmpty(searchCriteria.m_market) && searchCriteria.m_market != "0")
                        {
                            result = result.Where(o => o.Market == searchCriteria.m_market);
                        }
                        if (!string.IsNullOrEmpty(searchCriteria.m_offer_type))
                        {
                            result = result.Where(o => o.Offer_Type == searchCriteria.m_offer_type);
                        }
                        if (searchCriteria.m_rooms_max != null)
                        {
                            result = result.Where(o => o.Rooms <= searchCriteria.m_rooms_max);
                        }
                        if (searchCriteria.m_rooms_min != null)
                        {
                            result = result.Where(o => o.Rooms >= searchCriteria.m_rooms_min);
                        }

                        break;
                    case "D":
                        if (searchCriteria.d_area_max != null)
                        {
                            result = result.Where(o => o.Area <= searchCriteria.d_area_max);
                        }
                        if (searchCriteria.d_area_min != null)
                        {
                            result = result.Where(o => o.Area >= searchCriteria.d_area_min);
                        }
                        if (!string.IsNullOrEmpty(searchCriteria.d_market) && searchCriteria.d_market != "0")
                        {
                            result = result.Where(o => o.Market == searchCriteria.d_market);
                        }
                        if (!string.IsNullOrEmpty(searchCriteria.d_offer_type))
                        {
                            result = result.Where(o => o.Offer_Type == searchCriteria.d_offer_type);
                        }
                        if (searchCriteria.d_rooms_max != null)
                        {
                            result = result.Where(o => o.Rooms <= searchCriteria.d_rooms_max);
                        }
                        if (searchCriteria.d_rooms_min != null)
                        {
                            result = result.Where(o => o.Rooms >= searchCriteria.d_rooms_min);
                        }
                        break;
                    case "N":
                        if (searchCriteria.n_area_max != null)
                        {
                            result = result.Where(o => o.Area <= searchCriteria.n_area_max);
                        }
                        if (searchCriteria.n_area_min != null)
                        {
                            result = result.Where(o => o.Area >= searchCriteria.n_area_min);
                        }
                        if (!string.IsNullOrEmpty(searchCriteria.n_offer_type))
                        {
                            result = result.Where(o => o.Offer_Type == searchCriteria.n_offer_type);
                        }
                        if (!string.IsNullOrEmpty(searchCriteria.n_parcel_type))
                        {
                            result = result.Where(o => o.Parcel_Type == searchCriteria.n_parcel_type);
                        }
                        break;
                    case "G":
                        if (searchCriteria.g_area_max != null)
                        {
                            result = result.Where(o => o.Area <= searchCriteria.g_area_max);
                        }
                        if (searchCriteria.g_area_min != null)
                        {
                            result = result.Where(o => o.Area >= searchCriteria.g_area_min);
                        }
                        if (!string.IsNullOrEmpty(searchCriteria.g_offer_type))
                        {
                            result = result.Where(o => o.Offer_Type == searchCriteria.g_offer_type);
                        }
                        if (!string.IsNullOrEmpty(searchCriteria.g_garage_construction))
                        {
                            result = result.Where(o => o.Garage_Construction == searchCriteria.g_garage_construction);
                        }
                        break;
                    case "L":
                        if (searchCriteria.l_area_max != null)
                        {
                            result = result.Where(o => o.Area <= searchCriteria.l_area_max);
                        }
                        if (searchCriteria.l_area_min != null)
                        {
                            result = result.Where(o => o.Area >= searchCriteria.l_area_min);
                        }
                        if (!string.IsNullOrEmpty(searchCriteria.l_offer_type))
                        {
                            result = result.Where(o => o.Offer_Type == searchCriteria.l_offer_type);
                        }
                        if (!string.IsNullOrEmpty(searchCriteria.l_local_purpose))
                        {
                            result = result.Where(o => o.Local_Purpose == searchCriteria.l_local_purpose);
                        }
                        break;
                    case "P":
                        break;

                }

                if (!string.IsNullOrEmpty(searchCriteria.time))
                {
                    if (searchCriteria.time != "0")
                    {
                        DateTime? referenceDateTime = null;
                        switch (searchCriteria.time)
                        {
                            case "1":
                                referenceDateTime = DateTime.Now.AddDays(-1);
                                break;
                            case "2":
                                referenceDateTime = DateTime.Now.AddDays(-7);
                                break;
                            case "3":
                                referenceDateTime = DateTime.Now.AddMonths(-1);
                                break;
                            case "4":
                                referenceDateTime = DateTime.Now.AddMonths(-3);
                                break;
                            default:
                                break;
                        }

                        if (referenceDateTime.HasValue)
                        {
                            result = result.Where(o => o.Entered_DT > referenceDateTime.Value);
                        }
                    }
                }
            }
            #endregion

            OfferListViewModel model = new OfferListViewModel
            {
                Offers = result.OrderBy(o => o.Id).
                                Skip((page - 1) * pageSize).
                                Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = searchCriteria.category == null ? result.Count() : result.Where(o=> o.Category == searchCriteria.category).Count()
                },
                CurrentCategory = searchCriteria.category,
                SearchCriteria = searchCriteria
            };
            return View(model);
        }

        public FileContentResult GetImage(int id)
        {
            Photo photo = repository.GetPhotoForId(id);
            if (photo != null)
            {
                return File(photo.PhotoFile, photo.MimeType);
            }
            else
            {
                return null;
            }
        }

        public ActionResult DisplayImagesForOffer(int offerId)
        {
            List<Photo> photos = repository.GetPhotosForOffer(offerId);
               
            return View("DisplayImagesForOffer", photos.ToList());
        }



    }
}