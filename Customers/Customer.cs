using System.Collections.Generic;
using TharstenAPI.Models.Addresses;
using TharstenAPI.Models.Base;
using TharstenAPI.Models.Courier;
using TharstenAPI.Models.CustomField;
using TharstenAPI.Models.Data;

namespace TharstenAPI.Models.Customers
{
    public class Customer
    {
        public int? ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool? IsDeliveryAddress { get; set; }
        public bool? IsDefaultDeliveryAddress { get; set; }
        public Address Address { get; set; }
        public int? Contactid { get; set; }
        public string Contact { get; set; }
        public string ContactEmail { get; set; }
        public string Ref1 { get; set; }
        public string Ref2 { get; set; }
        public string Ref3 { get; set; }
        public string WebUrl { get; set; }
        public string Comments { get; set; }
        public string TaxRegNo { get; set; }
        public int? PostingAccountId { get; set; }
        public string PostingAccountCode { get; set; }
        public Tax Tax { get; set; }
        public int? SalesRepUserId { get; set; }
        public string TimeStamp { get; set; }
        public string SalesRepUsername { get; set; }
        public int? CSRUserID { get; set; }
        public string CSRUserName { get; set; } 
        public List<SimpleCustomFieldWithValue> CustomFields { get; set; }
        public List<CustomerAddress> DeliveryAddresses { get; set; }
        public Currency DefaultCurrency { get; set; }
        public List<CourierType> CourierTypes { get; set; }
        public int? DefaultCourierId { get; set; }
        public int? DefaultCourierServiceId { get; set; }
        public SalesTaxCode DefaultSalesTaxCode { get; set; }
        public Data.SalesTaxItem DefaultSalesTaxItem { get; set; }
        public SalesTaxCode DefaultCarriageSalesTaxCode { get; set; }
        public List<Courier> Couriers { get; set; }
        public bool? Deleted { get; set; }
        public List<SecurityGroup> SecurityGroups { get; set; }

    }
}