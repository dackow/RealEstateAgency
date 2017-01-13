using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateAgency.WebUI.Models
{
    public class SearchCriteria
    {
        public string category { get; set;}
        public string time { get; set; }
        public decimal? price_min { get; set; }
        public decimal? price_max { get; set; }
        public string location { get; set; }


        public string m_offer_type{ get; set;}
        public string m_market{ get; set;}
        public decimal? m_area_min{ get; set;}
        public decimal? m_area_max{ get; set;}
        public int? m_rooms_min{ get; set;}
        public int? m_rooms_max{ get; set;}

        public string d_offer_type{ get; set;}
        public string d_market{ get; set;}
        public decimal? d_area_min{ get; set;}
        public decimal? d_area_max{ get; set;}
        public int? d_rooms_min{ get; set;}
        public int? d_rooms_max{ get; set;}

        public string n_offer_type{ get; set;}
        public decimal? n_area_min{ get; set;}
        public decimal? n_area_max{ get; set;}
        public string n_parcel_type{ get; set;}

        public string g_offer_type{ get; set;}
        public decimal? g_area_min{ get; set;}
        public decimal? g_area_max{ get; set;}
        public string g_garage_construction{ get; set;}

        public string l_offer_type{ get; set;}
        public decimal? l_area_min{ get; set;}
        public decimal? l_area_max{ get; set;}
        public string l_local_purpose{ get; set;}


    }
}