using System.Collections.Generic;
using TharstenAPI.Models.CustomField;

namespace TharstenAPI.Models.Customers
{
    public class CustomerPackage : BaseEntityPackageModel
    {
        public List<Customer> Items { get; set; }
    }
}