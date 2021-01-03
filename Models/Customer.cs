using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_CommerceSystemWithRestAPI.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public float Balance { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public ICollection<Order> Orders { get; set; }

        public ICollection<WishlistItem> WishlistItems { get; set; }
        public ICollection<WalletEntry> WalletEntries { get; set; }
        public ICollection<OrderedItem> OrderedItems { get; set; }
    }
}