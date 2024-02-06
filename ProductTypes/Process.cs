using System.Collections.Generic;
using TharstenAPI.Models.Enums;

namespace TharstenAPI.Models.ProductTypes
{
    public class Process
    {
        public int? ProcessTypeId { get; set; }
        public int? LineNumber { get; set; }
        public bool? IsDefault { get; set; }
        public string ProcessType { get; set; }
        public bool? IsRequired { get; set; }
        public float? DefaultQuantity { get; set; }
        public int? DefaultCostCentreId { get; set; }
        public int? DefaultOutworkId { get; set; }
        public string DefaultMaterialCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public EnumValueAndName Type { get; set; }
        public EnumValueAndName OpType { get; set; }
        public EnumValueAndName QuantityType { get; set; }
        public bool? IsPerSide { get; set; }
        public EnumValueAndName MaterialRequirement { get; set; }
        public List<ProcessCostCentre> CostCentres { get; set; }
        public List<ProcessOutwork> Outworks { get; set; }
    }
}