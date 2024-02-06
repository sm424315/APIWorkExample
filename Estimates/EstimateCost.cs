namespace TharstenAPI.Models.Estimates
{
    public class EstimateCost
    {
        public float? Paper { get; set; }
        public float? OriginationMaterial { get; set; }
        public float? OtherMaterial { get; set; }
        public float? Outwork { get; set; }
        public float? Carriage { get; set; }
        public float? PrePress { get; set; }
        public float? Printing { get; set; }
        public float? Finishing { get; set; }
        public float? OrderExpense { get; set; }
        public float? TotalCost { get; set; }
    }
}