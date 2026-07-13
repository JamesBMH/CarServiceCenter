using CarServiceCenter.Application.DTOs;
using CarServiceCenter.Domain.Entities;
using CarServiceCenter.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CarServiceCenter.Application.Services
{
    public class ServiceTypeService
    {
        private readonly AppDbContext _context;

        public ServiceTypeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ServiceTypeDto>> GetAllAsync()
        {
            return await _context.ServiceTypes
                .Select(s => new ServiceTypeDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    EstimatedDuration = s.EstimatedDuration,
                    BasePrice = s.BasePrice
                })
                .ToListAsync();
        }

        public async Task<ServiceTypeDto?> GetByIdAsync(int id)
        {
            return await _context.ServiceTypes
                .Where(s => s.Id == id)
                .Select(s => new ServiceTypeDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    EstimatedDuration = s.EstimatedDuration,
                    BasePrice = s.BasePrice
                })
                .FirstOrDefaultAsync();
        }

        public async Task<ServiceTypeDto> CreateAsync(CreateServiceTypeDto dto)
        {
            var serviceType = new ServiceType
            {
                Name = dto.Name,
                Description = dto.Description,
                EstimatedDuration = dto.EstimatedDuration,
                BasePrice = dto.BasePrice
            };

            _context.ServiceTypes.Add(serviceType);
            await _context.SaveChangesAsync();

            return new ServiceTypeDto
            {
                Id = serviceType.Id,
                Name = serviceType.Name,
                Description = serviceType.Description,
                EstimatedDuration = serviceType.EstimatedDuration,
                BasePrice = serviceType.BasePrice
            };
        }
    }
}
