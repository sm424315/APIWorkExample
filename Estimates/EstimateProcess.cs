using TharstenAPI.Models.Enums;

namespace TharstenAPI.Models.Estimates
{
    public class EstimateProcess
    {
        public EnumValueAndName Type { get; set; }
        public int? CostCentreId { get; set; }
        public int? TotalDurationMinutes { get; set; }
    }
}