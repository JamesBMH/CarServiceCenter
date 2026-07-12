using CarServiceCenter.Application.DTOs;
using CarServiceCenter.Domain.Entities;
using CarServiceCenter.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CarServiceCenter.Application.Services
{
    public class VehicleService
    {
        private readonly AppDbContext _context;

        public VehicleService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<VehicleDto>> GetAllAsync()
        {
            return await _context.Vehicles
                .Include(v => v.Customer)
                .Select(v => new VehicleDto
                {
                    Id = v.Id,
                    Make = v.Make,
                    Year = v.Year,
                    LicensePlate = v.LicensePlate,
                    CustomerId = v.CustomerId,
                    CustomerName = v.Customer.FirstName + " " + v.Customer.LastName
                })
                .ToListAsync();
        }

        public async Task<VehicleDto?> GetByIdAsync(int id)
        {
            return await _context.Vehicles
                .Include(v => v.Customer)
                .Where(v => v.Id == id)
                .Select(v => new VehicleDto
                {
                    Id = v.Id,
                    Make = v.Make,
                    Model = v.Model,
                    Year = v.Year,
                    LicensePlate = v.LicensePlate,
                    CustomerId = v.CustomerId,
                    CustomerName = v.Customer.FirstName + " " + v.Customer.LastName
                })
                .FirstOrDefaultAsync();
        }

        public async Task<VehicleDto> CreateAsync(CreateVehicleDto dto)
        {
            var vehicle = new Vehicle
            {
                Make = dto.Make,
                Model = dto.Model,
                Year = dto.Year,
                LicensePlate = dto.LicensePlate,
                CustomerId = dto.CustomerId
            };

            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();

            var created = await GetByIdAsync(vehicle.Id);
            return created!;
        }
    }
}
