namespace TharstenAPI.Models.Stock
{
    public class JobContainer
    {
        public int? ContainerId { get; set; }
        public string UniqueContainerIdentifier { get; set; }
        public string ContainerName { get; set; }
        public int? Quantity { get; set; }
    }
}