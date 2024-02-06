namespace TharstenAPI.Models.Estimates
{
    public class EstimateVersion
    {
        public int? Id { get; set; }
        public int? EstimateId { get; set; }
        public int? EstimatePartId { get; set; }
        public string Description { get; set; }
        public float? Quantity { get; set; }
        public int? LineNumber { get; set; }
    }
}