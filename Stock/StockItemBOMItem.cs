namespace TharstenAPI.Models.Stock
{
    public class StockItemBOMItem
    {
        public int? Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal? Quantity { get; set; }
        public bool? IsBOM { get; set; }
        public int? BOMRevision { get; set; }
    }
}