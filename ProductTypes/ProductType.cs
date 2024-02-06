using System.Collections.Generic;
using TharstenAPI.Models.Dimensions;
using TharstenAPI.Models.Enums;

namespace TharstenAPI.Models.ProductTypes
{
    public class ProductType
    {
        public int? Id { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; } 
        public EnumValueAndName Type { get; set; }
        public string DefaultPageSize { get; set; }
        public EnumValueAndName DefaultOrientation { get; set; }
        public bool? IsCustomSizeAllowed { get;set; }
        public float? MinimumWidth { get; set; }
        public float? MaximumWidth { get; set; }
        public float? MinimumDepth { get; set; }
        public float? MaximumDepth { get; set; }
        public int? MaximumPages { get; set; }
        public int? MinimumQuantity { get; set; }
        public int? MaximumQuantity { get; set; }
        public int? QuantityIncrement { get; set; }
        public string Preview { get; set; }
        public Dimension AlowedDimensions { get; set; }
        public List<Process> Processes { get; set; }
        public List<ProductTypePart> Parts { get; set; }
        public EnumValueAndName Availability { get; set; }
        public EnumValueAndName Visibility { get; set; }
        public int[] ProductClassifications { get; set; }
    }
}