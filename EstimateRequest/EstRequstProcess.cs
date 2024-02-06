namespace TharstenAPI.Models.EstimateRequest
{
    public class EstRequestProcess
    {
        public int? ProcessTypeId { get; set; }
        public int? CostCentreId { get; set; }
        public int? OutworkId { get; set; }
        public string MaterialCode { get; set; }
        public float? Value { get; set; }
        public int? DurationInMinutes { get; set; }
    }
}