using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.Domain.Entities
{
    public class Offer
    {
        public int Id { get; set; }

        [DisplayName("Tytuł")]
        public string Name { get; set; }

        [DisplayName("Opis")]
        public string Description { get; set; }

        [DisplayName("Cena")]
        public decimal Price { get; set; }

        [DisplayName("Kategoria")]
        public string Category { get; set; }

        [DisplayName("Rodzaj oferty")]
        public string Offer_Type { get; set; }

        [DisplayName("Rynek")]
        public string Market { get; set; }

        [DisplayName("Miejscowość")]
        public string Location { get; set; }

        [DisplayName("Powierzchnia [w m2]")]
        public int Area { get; set; }

        [DisplayName("Liczba pokoi")]
        public int Rooms { get; set; }

        [DisplayName("Rodzaj działki")]
        public string Parcel_Type { get; set; }

        [DisplayName("Konstrukcja garażu")]
        public string Garage_Construction { get; set; }

        [DisplayName("Przeznaczenie lokalu")]
        public string Local_Purpose { get; set; }
    }
}
