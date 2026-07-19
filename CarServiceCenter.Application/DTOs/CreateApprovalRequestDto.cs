namespace CarServiceCenter.Application.DTOs
{
    public class CreateApprovalRequestDto
    {
        public string Description { get; set; } = string.Empty;
        public int BookingId { get; set; }
    }
}
