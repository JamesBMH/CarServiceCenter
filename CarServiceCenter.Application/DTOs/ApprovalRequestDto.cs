using CarServiceCenter.Domain.Enums;

namespace CarServiceCenter.Application.DTOs
{
    public class ApprovalRequestDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public ApprovalRequestStatus Status { get; set; }
        public DateTime RequestedAt { get; set; }
        public DateTime? ResolvedAt { get; set; }
        public string? AdvisorNotes { get; set; }
        public int BookingId { get; set; }
    }
}
