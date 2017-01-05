using RealEstateAgency.WebUI.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Web;

namespace RealEstateAgency.WebUI.Helpers
{
    public class ResourceHelper
    {
        
        public static string GetCategoryNameForCode(string code)
        {
            string res = null;
            if (!string.IsNullOrEmpty(code))
            {
                res = Resources.ResourceManager.GetString(code);
            }
            return res;
        }
    }
}