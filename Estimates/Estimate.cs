using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TharstenAPI.Models.Customers;
using TharstenAPI.Models.CustomField;
using TharstenAPI.Models.Enums;

namespace TharstenAPI.Models.Estimates
{
    public class Estimate
    {
        public int? Id { get; set; }
        public string EstimateRef { get; set; }
        public string CreatedDateTime { get; set; }
        public string EstimateDate { get; set; }
        public string RequiredDate { get; set; }
        public int? Quantity { get; set; }
        public float? Weight { get; set; }
        public EstimateCost Costs { get; set; }
        public int? ProjectId { get; set; }
        public EstimateMarkup Markups { get; set; }
        public EstimateCost MarkedUpCosts { get; set; }
        public bool? UsePriceList { get; set; }
        public bool? AddCarriageToPriceList { get; set; }
        public float? PriceExclShipping { get; set; }
        public float? PriceBeforeRounding { get; set; }
        public float? Price { get; set; }
        public float? ForeignPrice { get; set; }
        public Data.Currency Currency { get; set; }
        public AdditionalFinancialInformation AdditionalFinancialInformation { get; set; }
        public bool? QuantityPerPaperline { get; set; }
        public int? Version { get; set; }
        public EnumValueAndName Ordered { get; set; }
        public string JobCreated { get; set; }
        public string JobType { get; set; }
        public string Estimator { get; set; }
        public string LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public string Title { get; set; }
        public bool? IsRevision { get; set; }
        public int? RevisedFromEstimateId { get; set; }
        public BaseCustomer Customer { get; set; }
        public string DeliveryCode { get; set; }
        public string DeliveryContact { get; set; }
        public string Ref1 { get; set; }
        public string Ref2 { get; set; }
        public string Ref3 { get; set; }
        public string Ref4 { get; set; }
        public string Ref5 { get; set; }
        public string Ref6 { get; set; }
        public string Ref7 { get; set; }
        public string Ref8 { get; set; }
        public string Ref9 { get; set; }
        public string Ref10 { get; set; }
        public int? ProductTypeId { get; set; }
        public string CustomStatus { get; set; }
        public int? CourierServiceId { get; set; }
        public string CourierCode { get; set; }
        public float? CourierPrice { get; set; }
        public bool? CarriageIsAnExtra { get; set; }
        public bool? Expired { get; set; }
        public int? RFQID { get; set; }
        public EnumValueAndName EstimateType { get; set; }
        public List<MultipleQuantity> MultipleQuantities { get; set; }
        public List<EstimateProcess> Processes { get; set; }
        public List<EstimatePart> Parts { get; set; }
        public string TimeStamp { get; set; }
        public SimpleCustomFieldWithValue CustomFields { get; set; }
        public List<Sheet> Sheets { get; set; }
    }
}
