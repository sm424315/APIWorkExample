using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TharstenAPI.Models.Addresses;

namespace TharstenAPI.Models.Customers
{
    public class BaseCustomer
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool? IsDeliveryAddress { get; set; }
        public bool? IsDefaultDeliveryAddress { get; set; }
        public Address Address { get; set; }
        public int? ContactId { get; set; }
        public string Contact { get; set; }
        public string Ref1 { get; set; }
        public string Ref2 { get; set; }
        public string Ref3 { get; set; }
        public string WebUrl { get; set; }
        public string Comments { get; set; }
        public string TaxRegNo { get; set; }
        public string TimeStamp { get; set; }
    }
}
