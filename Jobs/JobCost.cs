using TharstenAPI.Models.Enums;

namespace TharstenAPI.Models.Jobs
{
    public class JobCost
    {
        public EnumValueAndName Type { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string InvoiceNo { get; set; }
        public string GSM { get; set; }
        public string SizeCode { get; set; }
        public float? Quantity { get; set; }
        public float? Value { get; set; }
        public string Category { get; set; }
        public string PostDateTime { get; set; }
        public int? ItemId { get; set; }
    }
}