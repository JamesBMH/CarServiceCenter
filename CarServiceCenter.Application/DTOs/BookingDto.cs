using CarServiceCenter.Domain.Enums;

namespace CarServiceCenter.Application.DTOs
{
    public class BookingDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public BookingStatus Status { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public int VehicleId { get; set; }
        public string VehicleInfo { get; set; } = string.Empty;
        public int ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; } = string.Empty;
        public int? TechnicianId { get; set; } 
        public string? TechnicianName { get; set; }
    }
}
