using System.Collections.Generic;
using TharstenAPI.Models.Enums;

namespace TharstenAPI.Models.ProductTypes
{
    public class ProcessCostCentre
    {
        public int? Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool? IsDefaultCostCentre { get; set; }
        public List<Material> Materials { get; set; }
        public float? DefaultQuantity { get; set; }
        public float? DefaultMinutesPerItem { get; set; }
        public EnumValueAndName QuantityType { get; set; }
        public string QuantityTypeDescription { get; set; }
    }
}