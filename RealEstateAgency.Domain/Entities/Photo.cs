using RealEstateAgency.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealEstateAgency.WebUI.Models
{
    public class Photo
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("Tytuł")]
        [StringLength(100)]
        public string Title { get; set; }

        public byte[] PhotoFile { get; set; }

        public string MimeType { get; set; }

        public virtual Offer Offer { get; set; }
    }
}