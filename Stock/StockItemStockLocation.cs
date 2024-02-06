using System.Collections.Generic;

namespace TharstenAPI.Models.Stock
{
    public class StockItemStockLocation
    {
        public int? Id { get; set; }
        public decimal? Quantity { get; set; }
        public string CheckDigit { get; set; }
        public List<BatchQuantity> BatchQuantities { get; set; }
        public List<JobContainer> JobContainers { get; set; }
    }
}