using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TharstenAPI.Models.Courier;
using TharstenAPI.Models.Customers;
using TharstenAPI.Models.CustomField;
using TharstenAPI.Models.Dimensions;
using TharstenAPI.Models.Enums;

namespace TharstenAPI.Models.EstimateRequest
{
    public class EstRequestProduct
    {
        public int? Id { get; set; }
        public string EstimateRef { get; set; }
        [JsonProperty("ProjectID")]
        public int? ProjectId { get; set; }
        public string Title { get; set; }
        public int? IsTemplate { get; set; }
        [JsonProperty("EstimatorID")]
        public int? EstimatorId { get; set; }
        public int? ProductTypeId { get; set; }
        public Dimension FinishedSize { get; set; }
        public EnumValueAndName BindingSide { get; set; }
        public EnumValueAndName Orientation { get; set; }
        public int Quantity { get; set; }
        public EnumValueAndName CoverType { get; set; }
        public string RequiredDateTime { get; set; }
        public BaseCustomer Customer { get; set; }
        public BaseCustomer DeliveryCustomer { get; set; }
        public string JobType { get; set; }
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
        public float? TotalPrice { get; set; }
        public float? CustomerUpliftPercentage { get; set; }
        public CourierServicePrice CourierDetails { get; set; }
        public List<EstRequestProcess> Processes { get; set; }
        public SimpleCustomFieldWithValue CustomFields { get; set; }
        public List<EstRequestPart> Parts { get; set; }
        public bool? IncludeAdditionalFinancialInformation { get; set; }
        public bool? IgnoreShipping { get; set; }

    }
}
