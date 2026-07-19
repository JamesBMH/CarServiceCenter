using CarServiceCenter.Domain.Enums;

namespace CarServiceCenter.Application.DTOs
{
    public class BookingServiceItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsLocked { get; set; }
        public bool IsAdvisorAdded { get; set; }
        public BookingServiceItemStatus Status { get; set; }
        public int BookingId { get; set; }
    }
}
