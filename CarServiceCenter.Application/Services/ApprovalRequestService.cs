using CarServiceCenter.Application.DTOs;
using CarServiceCenter.Domain.Entities;
using CarServiceCenter.Domain.Enums;
using CarServiceCenter.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CarServiceCenter.Application.Services
{
    public class ApprovalRequestService
    {
        private readonly AppDbContext _context;

        public ApprovalRequestService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ApprovalRequestDto>> GetByBookingAsync(int bookingId)
        {
            return await _context.ApprovalRequests
                .Where(a => a.BookingId == bookingId)
                .Select(a => new ApprovalRequestDto
                {
                    Id = a.Id,
                    Description = a.Description,
                    Status = a.Status,
                    RequestedAt = a.RequestedAt,
                    ResolvedAt = a.ResolvedAt,
                    AdvisorNotes = a.AdvisorNotes,
                    BookingId = a.BookingId
                })
                .ToListAsync();
        }

        public async Task<ApprovalRequestDto?> GetByIdAsync(int id)
        {
            return await _context.ApprovalRequests
                .Where(a => a.Id == id)
                .Select(a => new ApprovalRequestDto
                {
                    Id = a.Id,
                    Description = a.Description,
                    Status = a.Status,
                    RequestedAt = a.RequestedAt,
                    ResolvedAt = a.ResolvedAt,
                    AdvisorNotes = a.AdvisorNotes,
                    BookingId = a.BookingId
                })
                .FirstOrDefaultAsync();
        }

        public async Task<ApprovalRequestDto> CreatedAsync(CreateApprovalRequestDto dto)
        {
            var approvalRequest = new ApprovalRequest
            {
                Description = dto.Description,
                BookingId = dto.BookingId,
                Status = ApprovalRequestStatus.Pending,
                RequestedAt = DateTime.UtcNow
            };

            _context.ApprovalRequests.Add(approvalRequest);
            await _context.SaveChangesAsync();

            var created = await GetByIdAsync(approvalRequest.Id);
            return created!;
        }
    }
}
