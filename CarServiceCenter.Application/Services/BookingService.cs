using CarServiceCenter.Application.DTOs;
using CarServiceCenter.Domain.Entities;
using CarServiceCenter.Domain.Enums;
using CarServiceCenter.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CarServiceCenter.Application.Services
{
    public class BookingService
    {
        private readonly AppDbContext _context;

        public BookingService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<BookingDto>> GetAllAsync()
        {
            return await _context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.Vehicle)
                .Include(b => b.ServiceType)
                .Include(b => b.Technician)
                .Select(b => new BookingDto
                {
                    Id = b.Id,
                    CreatedAt = b.CreatedAt,
                    Status = b.Status,
                    CustomerId = b.CustomerId,
                    CustomerName = b.Customer.FirstName + " " + b.Customer.LastName,
                    VehicleId = b.VehicleId,
                    VehicleInfo = b.Vehicle.Year + " " + b.Vehicle.Make + " " + b.Vehicle.Model,
                    ServiceTypeId = b.ServiceTypeId,
                    ServiceTypeName = b.ServiceType.Name,
                    TechnicianId = b.TechnicianId,
                    TechnicianName = b.Technician != null ? b.Technician.FirstName + " " + b.Technician.LastName : null
                })
                .ToListAsync();
        }

        public async Task<BookingDto?> GetByIdAsync(int id)
        {
            return await _context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.Vehicle)
                .Include(b => b.ServiceType)
                .Include(b => b.Technician)
                .Where(b => b.Id == id)
                .Select(b => new BookingDto
                {
                    Id = b.Id,
                    CreatedAt = b.CreatedAt,
                    Status = b.Status,
                    CustomerId = b.CustomerId,
                    CustomerName = b.Customer.FirstName + " " + b.Customer.LastName,
                    VehicleId = b.VehicleId,
                    VehicleInfo = b.Vehicle.Year + " " + b.Vehicle.Make + " " + b.Vehicle.Model,
                    ServiceTypeId = b.ServiceTypeId,
                    ServiceTypeName = b.ServiceType.Name,
                    TechnicianId = b.TechnicianId,
                    TechnicianName = b.Technician != null ? b.Technician.FirstName + " " + b.Technician.LastName : null
                })
                .FirstOrDefaultAsync();
        }

        public async Task<BookingDto> CreateAsync(CreateBookingDto dto)
        {
            var booking = new Booking
            {
                CustomerId = dto.CustomerId,
                VehicleId = dto.VehicleId,
                ServiceTypeId = dto.ServiceTypeId,
                Status = BookingStatus.Scheduled,
                CreatedAt = DateTime.UtcNow
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            var created = await GetByIdAsync(booking.Id);
            return created!;
        }
    }
}
