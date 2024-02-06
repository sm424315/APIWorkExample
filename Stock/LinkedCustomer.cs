using TharstenAPI.Models.Enums;

namespace TharstenAPI.Models.Stock
{
    public class LinkedCustomer
    {
        public string CustomerCode { get; set; }
        public int? MinOrderQty { get; set; }
        public int? MaxOrderQty { get; set; }
        public EnumValueAndName CustomerProductUsage { get; set; }
        public string Alias { get; set; }
    }
}