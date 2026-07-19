namespace CarServiceCenter.Application.DTOs
{
    public class CreateBookingDto
    {
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public int ServiceTypeId { get; set; }
    }
}
