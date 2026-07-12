namespace CarServiceCenter.Application.DTOs
{
    public class CreateVehicleDto
    {
        public string Make { get; set; } = string.Empty;
        public string Model {  get; set; } = string.Empty;
        public int Year { get; set; }
        public string LicensePlate { get; set; } = string.Empty;
        public int CustomerId { get; set; }
    }
}
