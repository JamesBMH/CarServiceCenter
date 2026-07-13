namespace CarServiceCenter.Application.DTOs
{
    public class CreateServiceTypeDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int EstimatedDuration { get; set; }
        public decimal BasePrice { get; set; }
    }
}
