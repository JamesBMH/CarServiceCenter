using CarServiceCenter.Application.DTOs;
using CarServiceCenter.Domain.Entities;
using CarServiceCenter.Domain.Enums;
using CarServiceCenter.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CarServiceCenter.Application.Services
{
    public class BookingServiceItemService
    {
        private readonly AppDbContext _context;

        public BookingServiceItemService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<BookingServiceItemDto>> GetByBookingAsync(int bookingId)
        {
            return await _context.BookingServiceItems
                .Where(i => i.BookingId == bookingId)
                .Select(i => new BookingServiceItemDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    IsLocked = i.IsLocked,
                    IsAdvisorAdded = i.IsAdvisorAdded,
                    Status = i.Status,
                    BookingId = i.BookingId
                })
                .ToListAsync();
        }

        public async Task<BookingServiceItemDto?> GetByIdAsync(int id)
        {
            return await _context.BookingServiceItems
                .Where(i => i.Id == id)
                .Select(i => new BookingServiceItemDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    IsLocked = i.IsLocked,
                    IsAdvisorAdded = i.IsAdvisorAdded,
                    Status = i.Status,
                    BookingId = i.BookingId
                })
                .FirstOrDefaultAsync();
        }

        public async Task<BookingServiceItemDto> CreateAsync(CreateBookingServiceItemDto dto)
        {
            var item = new BookingServiceItem
            {
                Name = dto.Name,
                IsLocked = dto.IsLocked,
                IsAdvisorAdded = dto.IsAdvisorAdded,
                Status = BookingServiceItemStatus.Pending,
                BookingId = dto.BookingId
            };

            _context.BookingServiceItems.Add(item);
            await _context.SaveChangesAsync();

            var created = await GetByIdAsync(item.Id);
            return created!;
        }
    }
}
