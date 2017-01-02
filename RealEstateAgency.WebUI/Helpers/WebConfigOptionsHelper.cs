using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace RealEstateAgency.WebUI.Helpers
{
    public class WebConfigOptionsHelper
    {
        private readonly Configuration config = WebConfigurationManager.OpenWebConfiguration(null);
        public string GetOption(string optionName)
        {
            string ret = null;
            if (!string.IsNullOrWhiteSpace(optionName))
            {
                if (config != null && config.AppSettings.Settings.Count > 0)
                {
                    KeyValueConfigurationElement customSetting = config.AppSettings.Settings[optionName];
                    if (customSetting != null)
                    {
                        ret = customSetting.Value;
                    }
                }
            }
            return ret;
        }
    }
}