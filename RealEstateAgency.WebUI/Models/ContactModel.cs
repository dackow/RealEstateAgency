using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealEstateAgency.WebUI.Models
{
    public class ContactModel
    {
        [Required(ErrorMessage = "Wprowadź swoje imię i nazwisko")]
        [DisplayName("Imię i nazwisko")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Wprowadź poprawny adres e-mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Wprowadź poprawny adres e-mail")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [DisplayName("Numer oferty")]
        public string OfferId { get; set; }

        [Required(ErrorMessage = "Wprowadź treść wiadomości")]
        [DisplayName("Treść")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}