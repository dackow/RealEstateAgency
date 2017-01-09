using RealEstateAgency.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.Domain.Abstract
{
    public interface IOfferRepository
    {
        IEnumerable<Offer> Offers { get; }
        void SaveOffer(Offer offer);
        Offer DeleteOffer(int id);
    }
}
