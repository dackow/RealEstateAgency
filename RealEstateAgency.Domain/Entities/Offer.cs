using RealEstateAgency.WebUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.Domain.Entities
{
    public class Offer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Oferta musi posiadać tytuł")]
        [DisplayName("Tytuł")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Oferta musi posiadać opis")]
        [DisplayName("Opis")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Oferta musi posiadać cenę")]
        [Range(0, 2000000, ErrorMessage = "Wprowadź realną cenę")]
        [DataType(DataType.Currency)]
        [DisplayName("Cena")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Oferta musi posiadać kategorię")]
        [DisplayName("Kategoria")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Oferta musi posiadać rodzaj")]
        [DisplayName("Rodzaj oferty")]
        public string Offer_Type { get; set; }

        [DisplayName("Rynek")]
        public string Market { get; set; }

        [Required(ErrorMessage = "Oferta musi lokalizację")]
        [DisplayName("Miejscowość")]
        public string Location { get; set; }

        [Range(0,200000,ErrorMessage = "Wprowadź realną powierzchnię")]
        [DisplayName("Powierzchnia [w m2]")]
        public int Area { get; set; }

        [Range(0, 50, ErrorMessage = "Wprowadź realną liczbę pokoi")]
        [DisplayName("Liczba pokoi")]
        public int Rooms { get; set; }

        [DisplayName("Rodzaj działki")]
        public string Parcel_Type { get; set; }

        [DisplayName("Konstrukcja garażu")]
        public string Garage_Construction { get; set; }

        [DisplayName("Przeznaczenie lokalu")]
        public string Local_Purpose { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Data utworzenia")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yy}")]
        public DateTime Entered_DT { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }
    }
}
