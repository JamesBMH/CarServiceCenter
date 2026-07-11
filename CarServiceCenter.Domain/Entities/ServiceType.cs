namespace CarServiceCenter.Domain.Entities
{
    public class ServiceType
    {
        public int Id {  get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description {  get; set; } = string.Empty;
        public int EstimatedDuration { get; set; }
        public decimal BasePrice { get; set; }
    }
}
