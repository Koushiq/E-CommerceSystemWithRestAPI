using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_CommerceSystemWithRestAPI.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public float Price { get; set; }
        public string Description { get; set; }
        
        public string FilePath { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int? OfferId { get; set; }
        public Offer Offer { get; set; }
        public ICollection<WishlistItem> WishlistItems { get; set; }
        public ICollection<OrderedItem> OrderedItems { get; set; }
    }
}