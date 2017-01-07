using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.Domain.Entities
{
    public class Offer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Offer_Type { get; set; }
        public string Market { get; set; }
        public string Location { get; set; }
        public int Area { get; set; }
        public int Rooms { get; set; }
        public string Parcel_Type { get; set; }
        public string Garage_Construction { get; set; }
        public string Local_Purpose { get; set; }
    }
}
