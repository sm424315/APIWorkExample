using TharstenAPI.Models.Dimensions;

namespace TharstenAPI.Models.Estimates
{
    public class Sheet
    {
        public int? Id { get; set; }
        public int? SheetNo { get; set; }
        public Dimension Dimensions { get; set; }
    }
}