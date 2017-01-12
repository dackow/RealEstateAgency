using RealEstateAgency.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateAgency.WebUI.Models
{
    public class OfferListViewModel
    {
        public IEnumerable<Offer> Offers { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public string CurrentCategory { get; set; }

        public SearchCriteria SearchCriteria{ get; set; }


    }
}