using RealEstateAgency.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateAgency.Domain.Entities;
using RealEstateAgency.WebUI.Models;

namespace RealEstateAgency.Domain.Concrete
{
    public class DBOffersRepository : IOfferRepository
    {
        private readonly READBContext context = new READBContext();
        public IEnumerable<Offer> Offers
        {
            get
            {
                return context.Offers;
            }
        }

        public IEnumerable<Photo> Photos
        {
            get
            {
                return context.Photos;
            }
        }

        

        public Offer DeleteOffer(int id)
        {
            Offer dbEntry = context.Offers.Find(id);

            if (dbEntry != null)
            {
                context.Offers.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public Photo GetPhotoForId(int id)
        {
            return context.Photos.Find(id);
        }

        public List<Photo> GetPhotosForOffer(int offerId)
        {
            return context.Photos.Where(p => p.Offer.Id == offerId).ToList();
        }

        public void SaveOffer(Offer offer)
        {
            if (offer.Id == 0)
            {
                context.Offers.Add(offer);
            }
            else
            {
                Offer dbEntry = context.Offers.Find(offer.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = offer.Name;
                    dbEntry.Description = offer.Description;
                    dbEntry.Area = offer.Area;
                    dbEntry.Category = offer.Category;
                    dbEntry.Garage_Construction = offer.Garage_Construction;
                    dbEntry.Local_Purpose = offer.Local_Purpose;
                    dbEntry.Location = offer.Location;
                    dbEntry.Market = offer.Market;
                    dbEntry.Offer_Type = offer.Offer_Type;
                    dbEntry.Parcel_Type = offer.Parcel_Type;
                    dbEntry.Price = offer.Price;
                    dbEntry.Rooms = offer.Rooms;
                }
            }
            context.SaveChanges();
        }
    }
}
