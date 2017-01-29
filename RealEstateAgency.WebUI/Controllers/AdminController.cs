using RealEstateAgency.Domain.Abstract;
using RealEstateAgency.Domain.Entities;
using RealEstateAgency.Domain.Setup;
using RealEstateAgency.WebUI.Helpers;
using RealEstateAgency.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        public ActionResult Index(string category)
        {
            var offers = from o in repository.Offers
                         select o;

            if (!string.IsNullOrEmpty(category))
            {
                offers = offers.Where(o => o.Category == category);
                ViewBag.SelectedCategory = "Kategoria: " + Setups.GetInstance().CATEGORIES[category];
            }
            else
            {
                ViewBag.SelectedCategory = "Wszystkie kategorie";
            }
            
            return View(offers);
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
        public ActionResult Edit(Offer offer, IEnumerable<HttpPostedFileBase> files)
        {
            if (ModelState.IsValid)
            {
                repository.SaveOffer(offer);

                //if pictures exist then remove them first 
                if (files != null && files.Count() > 0 && files.ToArray().GetValue(0) != null )
                {
                    DeleteImagesForOfferId(offer.Id);
                    SavePhotosCreateThumbnails(files, offer.Id);
                }
                TempData["message"] = string.Format("Oferta '{0}' została zapisana", offer.Name);
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
        public ActionResult Add(Offer offer, IEnumerable<HttpPostedFileBase> files)
        {
            if (ModelState.IsValid)
            {
                repository.SaveOffer(offer);

                ////process photo images
                //if (files != null)
                //{
                //    string PATH_TO_SAVE_IMAGES = Server.MapPath("~/AgencyImages");
                //    try
                //    {
                //        foreach (var photo in files)
                //        {
                //            string directory = Path.Combine(PATH_TO_SAVE_IMAGES, offer.Id.ToString());
                //            if (!Directory.Exists(directory))
                //            {
                //                Directory.CreateDirectory(directory);
                //            }

                //            if (!Directory.Exists(directory))
                //            {
                //                throw new Exception("Can't find or create the directory : " + directory);
                //            }
                //            //string path = Path.Combine(PATH_TO_SAVE_IMAGES, Path.GetFileName(photo.FileName));

                //            string fileName = Path.GetFileName(photo.FileName);
                //            string fullPath = Path.Combine(directory, fileName);
                //            photo.SaveAs(fullPath);

                //            string thumb_directory = Path.Combine(PATH_TO_SAVE_IMAGES, offer.Id.ToString(), "thumb");
                //            if (!Directory.Exists(thumb_directory))
                //            {
                //                Directory.CreateDirectory(thumb_directory);
                //            }
                //            if (!Directory.Exists(thumb_directory))
                //            {
                //                throw new Exception("Can't find or create the directory for thumbnails : " + directory);
                //            }
                //            else
                //            {
                //                string thumbFullPath = Path.Combine(thumb_directory, fileName);
                //                //create a thumbnail for the image
                //                using (Image im = Image.FromStream(photo.InputStream, true, true))
                //                {
                //                    int height = 200;// (im.Height / (im.Width / 200));
                //                    using (Image thumb = im.GetThumbnailImage(200, height, () => false, IntPtr.Zero))
                //                    {
                //                        thumb.Save(thumbFullPath);
                //                    }
                //                }
                //            }
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        TempData["message"] = "ERROR:" + ex.Message.ToString();
                //        return RedirectToAction("Index");
                //    }
                //}

                string msg = SavePhotosCreateThumbnails(files, offer.Id);
                if (!string.IsNullOrEmpty(msg))
                {
                    TempData["message"] = msg;
                }
                else
                {
                    TempData["message"] = string.Format("{0} has been saved", offer.Name);
                }
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

        private string SavePhotosCreateThumbnails(IEnumerable<HttpPostedFileBase> files, int id)
        {
            string error = string.Empty;
            if (files != null)
            {
                string PATH_TO_SAVE_IMAGES = Server.MapPath("~/AgencyImages");
                try
                {
                    foreach (var photo in files)
                    {
                        string directory = Path.Combine(PATH_TO_SAVE_IMAGES, id.ToString());
                        if (!Directory.Exists(directory))
                        {
                            Directory.CreateDirectory(directory);
                        }

                        if (!Directory.Exists(directory))
                        {
                            throw new Exception("Can't find or create the directory : " + directory);
                        }
                        //string path = Path.Combine(PATH_TO_SAVE_IMAGES, Path.GetFileName(photo.FileName));

                        string fileName = Path.GetFileName(photo.FileName);
                        string fullPath = Path.Combine(directory, fileName);
                        photo.SaveAs(fullPath);

                        string thumb_directory = Path.Combine(PATH_TO_SAVE_IMAGES, id.ToString(), "thumb");
                        if (!Directory.Exists(thumb_directory))
                        {
                            Directory.CreateDirectory(thumb_directory);
                        }
                        if (!Directory.Exists(thumb_directory))
                        {
                            throw new Exception("Can't find or create the directory for thumbnails : " + directory);
                        }
                        else
                        {
                            string thumbFullPath = Path.Combine(thumb_directory, fileName);
                            //create a thumbnail for the image
                            using (Image im = Image.FromStream(photo.InputStream, true, true))
                            {
                                int height = 200;// (im.Height / (im.Width / 200));
                                using (Image thumb = im.GetThumbnailImage(200, height, () => false, IntPtr.Zero))
                                {
                                    thumb.Save(thumbFullPath);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    error = "ERROR:" + ex.Message.ToString();
                }
            }
            return error;
        }

        public ActionResult Delete(int id)
        {
            Offer offer = repository.DeleteOffer(id);
            if (offer != null)
            {
                TempData["message"] = string.Format("Oferta '{0}' została usunięta", offer.Name);
            }
            return RedirectToAction("Index");
        }

        private string DeleteImagesForOfferId(int id)
        {
            string info = string.Empty;
            string PATH_TO_SAVE_IMAGES = Server.MapPath("~/AgencyImages");
            string directory = Path.Combine(PATH_TO_SAVE_IMAGES, id.ToString());
            if (!Directory.Exists(directory))
            {
                info = string.Format("Nie ma katalogu dla podanej oferty!");
            }
            else
            {
                Directory.Delete(directory, true);
                info = string.Format("Zdjęcia zostały usunięte");
            }
            return info;
        }
        public ActionResult DeleteImages(int id)
        {
            //string PATH_TO_SAVE_IMAGES = Server.MapPath("~/AgencyImages");
            //string directory = Path.Combine(PATH_TO_SAVE_IMAGES, id.ToString());
            //if (!Directory.Exists(directory))
            //{
            //    TempData["message"] = string.Format("Nie ma katalogu dla podanej oferty!");
            //}
            //else
            //{
            //    Directory.Delete(directory, true);
            //    TempData["message"] = string.Format("Zdjęcia zostały usunięte");
            //}

            TempData["message"] = DeleteImagesForOfferId(id);
            return RedirectToAction("Index");
        }

    }
}