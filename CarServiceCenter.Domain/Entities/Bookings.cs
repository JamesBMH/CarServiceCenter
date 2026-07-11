using CarServiceCenter.Domain.Enums;

namespace CarServiceCenter.Domain.Entities;

public class Booking
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public BookingStatus Status { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; } = null!;
    public int ServiceTypeId { get; set; }
    public ServiceType ServiceType { get; set; } = null!;
    public int? TechnitianId { get; set; }
    public Technitian? Technitian { get; set; }
}