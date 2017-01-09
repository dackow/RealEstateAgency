using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstateAgency.WebUI.Helpers
{
    public class DropDownListHelper
    {
        public static List<SelectListItem> GenerateDataToDropDown(Dictionary<string, string> dict, string selected_item)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in dict)
            {
                items.Add(new SelectListItem { Text = item.Value, Value = item.Key, Selected = item.Key == selected_item});
            }
            return items;
        }

    }
}