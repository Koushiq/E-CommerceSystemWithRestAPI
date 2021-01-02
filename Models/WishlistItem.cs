using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_CommerceSystemWithRestAPI.Models
{
    public class WishlistItem
    {
        public int WishlistItemId { get; set; }
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}