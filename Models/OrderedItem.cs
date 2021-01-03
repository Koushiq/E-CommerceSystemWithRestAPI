using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_CommerceSystemWithRestAPI.Models
{
    public class OrderedItem
    {
        public int OrderedItemId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        public Product Product { get; set; }
        [Required]
        public string OderItemStatus { get; set; } // incart,purchased
        public int? OrderId { get; set; }
        public Order Order { get; set; }
    }
}