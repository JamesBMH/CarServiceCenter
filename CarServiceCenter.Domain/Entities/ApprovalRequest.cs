using CarServiceCenter.Domain.Enums;

namespace CarServiceCenter.Domain.Entities
{
    public class ApprovalRequest
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public ApprovalRequestStatus Status { get; set; }
        public DateTime RequestedAt { get; set; }
        public DateTime? ResolvedAt { get; set; }
        public string? AdvisorNotes { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; } = null!;
    }
}
