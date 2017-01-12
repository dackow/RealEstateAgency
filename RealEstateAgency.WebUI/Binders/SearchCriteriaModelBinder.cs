using RealEstateAgency.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstateAgency.WebUI.Binders
{
    public class SearchCriteriaModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;
            
            return new SearchCriteria
            {
                category = request["category"],
                time = request["time"],

                m_offer_type = request["m_offer_type"],
                m_market = request["m_market"],
                m_price_max = String2Decimal(request["m_price_max"]),
                m_price_min = String2Decimal(request["m_price_min"]),
                m_location = request["m_location"],
                m_area_min = String2Decimal(request["m_area_min"]),
                m_area_max = String2Decimal(request["m_area_max"]),
                m_rooms_max = String2Int(request["m_rooms_max"]),
                m_rooms_min = String2Int(request["m_rooms_min"]),

                d_offer_type = request["d_offer_type"],
                d_market = request["d_market"],
                d_price_max = String2Decimal(request["d_price_max"]),
                d_price_min = String2Decimal(request["d_price_min"]),
                d_location = request["d_location"],
                d_area_min = String2Decimal(request["d_area_min"]),
                d_area_max = String2Decimal(request["d_area_max"]),
                d_rooms_max = String2Int(request["d_rooms_max"]),
                d_rooms_min = String2Int(request["d_rooms_min"]),

                n_offer_type = request["n_offer_type"],
                n_price_max = String2Decimal(request["n_price_max"]),
                n_price_min = String2Decimal(request["n_price_min"]),
                n_location = request["n_location"],
                n_area_min = String2Decimal(request["n_area_min"]),
                n_area_max = String2Decimal(request["n_area_max"]),
                n_parcel_type = request["n_parcel_type"],

                g_offer_type = request["g_offer_type"],               
                g_price_max = String2Decimal(request["g_price_max"]),
                g_price_min = String2Decimal(request["g_price_min"]),
                g_location = request["g_location"],
                g_area_min = String2Decimal(request["g_area_min"]),
                g_area_max = String2Decimal(request["g_area_max"]),
                g_garage_construction = request["g_garage_construction"],

                l_offer_type = request["l_offer_type"],
                l_price_max = String2Decimal(request["l_price_max"]),
                l_price_min = String2Decimal(request["l_price_min"]),
                //l_location = request["l_location"],
                l_area_min = String2Decimal(request["l_area_min"]),
                l_area_max = String2Decimal(request["l_area_max"]),
                l_local_purpose = request["l_local_purpose"],

                p_price_min = String2Decimal(request["p_price_min"]),
                p_price_max = String2Decimal(request["p_price_max"]),
                p_location = request["p_location"]    
            };                      
    }

        private decimal? String2Decimal(string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                return Convert.ToDecimal(s);
            }
            return null;
        }

        private int? String2Int(string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                return Convert.ToInt32(s);
            }
            return null;
        }

    }
}