using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_CommerceSystemWithRestAPI.Models
{
    public class WalletEntry
    {
        public int WalletEntryId { get; set; }
        public int CustomerId { get; set; }
        public float Amount { get; set; }
        public int? AdminId { get; set; }
        public DateTime RequestedAt { get; set; }
        public DateTime? ActionAt { get; set; }
        public Customer Customer { get; set; }
        public Admin Admin { get; set; }

    }
}