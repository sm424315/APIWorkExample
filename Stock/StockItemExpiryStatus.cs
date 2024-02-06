using TharstenAPI.Models.Enums;

namespace TharstenAPI.Models.Stock
{
    public class StockItemExpiryStatus
    {
        public EnumValueAndName Status { get; set; }
        public string ExpirtyDateTime { get; set; }
    }
}