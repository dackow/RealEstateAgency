using RealEstateAgency.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateAgency.Domain.Entities;

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
    }
}
