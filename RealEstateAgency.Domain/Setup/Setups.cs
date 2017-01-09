using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RealEstateAgency.Domain.Setup

{
    public class Setups
    {
        public readonly Dictionary<string, string> CATEGORIES = new Dictionary<string, string>{ { "M", "mieszkanie" },
                                                                                              { "D", "dom" },
                                                                                              { "N", "działka lub grunt" },
                                                                                              { "G", "garaż"},
                                                                                              { "L", "lokal użytkowy"},
                                                                                              { "P", "pokój"}};

        public Dictionary<string, string> OFFER_TYPES = new Dictionary<string, string> { { "S", "oferta sprzedaży" },
                                                                                                { "K", "oferta kupna" },
                                                                                                { "Z", "oferta zamiany" },
                                                                                                { "W", "oferta wynajmu" }};

        public readonly Dictionary<string, string> MARKETS = new Dictionary<string, string> { { "P", "pierwotny" },
                                                                                             { "W", "wtórny" } };

        public readonly Dictionary<string, string> PARCEL_TYPES = new Dictionary<string, string> { { "B", "budowlana"},
                                                                                                  {"R", "rolna"},
                                                                                                  {"I", "inwestycyjna"},
                                                                                                  {"U", "usługowa"},
                                                                                                  {"P","przemysłowa"},
                                                                                                  {"L","leśna"},
                                                                                                  {"O","rolno-budowlana"}};

        public readonly Dictionary<string, string> GARAGE_CONSTRUCTIONS = new Dictionary<string, string> { {"B", "blaszak"},
                                                                                                           {"M", "murowany"},
                                                                                                          {"P", "pod budynkiem"},
                                                                                                           {"W", "wiata"}};

        public readonly Dictionary<string, string> LOCAL_PURPOSE = new Dictionary<string, string> { {"0","-"},
                                                                                                   {"1","biuro"},
                                                                                                   {"2","hale i magazyny"},
                                                                                                   {"3","handel i usługi"},
                                                                                                   {"4","przemysł i produkcja"} };
        
        
        private Setups()
        {
        }

        private static Setups _instance;
        public static Setups GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Setups();
            }
            return _instance;
        }

        
    }
}
