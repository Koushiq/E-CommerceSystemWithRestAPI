using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_CommerceSystemWithRestAPI.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required]
        public float TotalCost { get; set; }
        [Required]
        public int Express { get; set; } //Boolean 0 or 1
        [Required]
        public string Status { get; set; } //To Be Delivered, On the Way, Delivered
        [Required]
        public DateTime DateOrdered { get; set; }
        public DateTime? DateDelivered { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderedItem> OrderedItems { get; set; } //No need for list of products as we have this, this is kind of like a "Cart"
        public int? ShipperId { get; set; }
        public Shipper Shipper { get; set; }
    }
}