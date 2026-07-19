namespace CarServiceCenter.Application.DTOs
{
    public class CreateBookingServiceItemDto
    {
        public string Name { get; set; } = string.Empty;
        public bool IsLocked { get; set; }
        public bool IsAdvisorAdded { get; set; }
        public int BookingId { get; set; }
    }
}
