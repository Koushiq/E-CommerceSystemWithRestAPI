using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_CommerceSystemWithRestAPI.Models
{
    public class Shipper
    {
        public int ShipperId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Phonenumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}