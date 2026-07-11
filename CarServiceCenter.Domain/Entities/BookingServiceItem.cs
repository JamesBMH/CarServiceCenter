using CarServiceCenter.Domain.Enums;

namespace CarServiceCenter.Domain.Entities
{
    public class BookingServiceItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsLocked { get; set; }
        public bool IsAdvisorAdded { get; set; }
        public BookingServiceItemStatus Status { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; } = null!;
    }
}
