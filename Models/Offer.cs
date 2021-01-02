using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_CommerceSystemWithRestAPI.Models
{
    public class Offer
    {
        public int OfferId { get; set; }
        [Required]
        public string OfferName { get; set; }
        [Required]
        public int DiscountRate { get; set; } //In Percentage (%)
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}