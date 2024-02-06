using System.Collections.Generic;
using TharstenAPI.Models.Enums;

namespace TharstenAPI.Models.ProductTypes
{
    public class ProductTypePart
    {
        public int? Id { get; set; }
        public EnumValueAndName Type { get; set; }
        public string Name { get; set; }
        public bool? IsDefault { get; set; }
        public bool? IsRequired { get; set; }
        public bool? IsMultipleAllowed { get; set; }
        public int? DefaultPages { get; set; }
        public string DefaultStockItemCode { get; set; }
        public string DefaultStockGroupCode { get; set; }
        public string DefaulitStockTypeCode { get; set; }
        public List<ProductTypePartMaterial> Materials { get; set; }
        public PartPages Paging { get; set; }
        public bool? DefaultDoubleSided { get; set; }
        public ProductTypePartColorRange ColourRange { get; set; }
        public List<Process> Processes { get; set; }
    }
}