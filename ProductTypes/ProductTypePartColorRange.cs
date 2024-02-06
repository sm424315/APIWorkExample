namespace TharstenAPI.Models.ProductTypes
{
    public class ProductTypePartColorRange
    {
        public bool? UseColourRange { get; set; }
        public ProductTypePartColorRange_Process Process { get; set; }
        public ProductTypePartColorRange_Spot Spot { get; set; }
        public ProductTypePartColorRange_Metallic Metallic { get; set; }
        public string DefaultCoating { get; set; }
    }
}