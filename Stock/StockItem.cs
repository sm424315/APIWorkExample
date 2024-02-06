using Newtonsoft.Json;
using System.Collections.Generic;
using TharstenAPI.Models.Attachments;
using TharstenAPI.Models.Base;
using TharstenAPI.Models.CustomField;
using TharstenAPI.Models.Enums;
using TharstenAPI.Models.Dimensions;
using TharstenAPI.Models.References;

namespace TharstenAPI.Models.Stock
{
    public class StockItem
    {
        public int? Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string ExtraInfo { get; set; }
        public EnumValueAndName Type { get; set; }
        public int? ProductTypes_Id { get; set; }
        public string ProductTypes_Name { get; set; }
        public Units Units { get; set; }
        public decimal? UnitPrice { get; set; }
        public Tax TaxDetails { get; set; }
        public decimal? Available { get; set; }
        public decimal? Balance { get; set; }
        public Dimension Dimensions { get; set; }
        public StockItemExpiryStatus ExpiryStatus { get; set; }
        public decimal? ReorderLevel { get; set; }
        public decimal? ReorderQuantity { get; set; }
        public bool? UseBatchControl { get; set; }public int? ProjectEstimateID { get; set; }
        public int? ProjectEstimateId { get; set; }
        public string ProjectEstimateTitle { get; set; }
        public int? DecimalPlaces { get; set; }
        public bool? IsBOM { get; set; }
        public int? BOMRevision { get; set; }
        public List<Reference> References { get; set; }
        public string Brand { get; set; }
        public string BrandDescription { get; set; }
        public string Group { get; set; }
        public string GroupDescription { get; set; }
        public string StockType { get; set; }
        public string StockTypeDescription { get; set; }
        [JsonProperty("Colour")]
        public string Color { get; set; }
        [JsonProperty("ColourDescription")]
        public string ColorDescription { get; set; }
        public string Category { get; set; }
        public string CategoryDescription { get; set; }
        public string ReportCode { get; set; }
        public string ReportCodeDescription { get; set; }
        public string CommodityCode { get; set; }
        public string AuthorityTypeCode { get; set; }
        public string AuthorityTypeDescription { get; set; }
        public string BasketAuthorityCode { get; set; }
        public string BasketAuthorityDescription { get; set; }
        public string PriceListMaterialGroupName { get; set; }
        public string SalesNominal { get; set; }
        [JsonProperty("SalesCostCentre")]
        public string SalesCostCenter { get; set; }
        public string SalesDepartment { get; set; }
        public string PurchaseNominal { get; set; }
        [JsonProperty("PurchaseCostCentre")]
        public string PurchaseCostCenter { get; set; }
        public string PurchaseDepartment { get; set; }
        public List<string> BarcodeReferences { get; set; }
        public List<string> UniqueBatchReferences { get; set; }
        public List<StockItemStockLocation> StockLocations { get; set; }
        public List<Attachment> Attachments { get; set; }
        public List<SimpleCustomFieldWithValue> CustomFields { get; set; }
        public List<LinkedCustomer> LinkedCustomers { get; set; }
        public List<StockItemBOMItem> BOMItems { get; set; }
    }
}