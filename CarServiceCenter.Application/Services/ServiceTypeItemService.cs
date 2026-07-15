using CarServiceCenter.Application.DTOs;
using CarServiceCenter.Domain.Entities;
using CarServiceCenter.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CarServiceCenter.Application.Services
{
    public class ServiceTypeItemService
    {
        private readonly AppDbContext _context;

        public ServiceTypeItemService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ServiceTypeItemDto>> GetAllAsync()
        {
            return await _context.ServiceTypeItems
                .Include(s => s.ServiceType)
                .Select(s => new ServiceTypeItemDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    IsLocked = s.IsLocked,
                    SortOrder = s.SortOrder,
                    ServiceTypeId = s.ServiceTypeId,
                    ServiceTypeName = s.ServiceType.Name
                })
                .ToListAsync();
        }

        public async Task<List<ServiceTypeItemDto>> GetByServiceTypeAsync(int serviceTypeId)
        {
            return await _context.ServiceTypeItems
                .Include(s => s.ServiceType)
                .Where(s => s.ServiceTypeId == serviceTypeId)
                .OrderBy(s => s.SortOrder)
                .Select(s => new ServiceTypeItemDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    IsLocked = s.IsLocked,
                    SortOrder = s.SortOrder,
                    ServiceTypeId = s.ServiceTypeId,
                    ServiceTypeName = s.ServiceType.Name
                })
                .ToListAsync();
        }

        public async Task<ServiceTypeItemDto?> GetByIdAsync(int id)
        {
            return await _context.ServiceTypeItems
                .Include(s => s.ServiceType)
                .Where(s => s.Id == id)
                .Select(s => new ServiceTypeItemDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    IsLocked = s.IsLocked,
                    SortOrder = s.SortOrder,
                    ServiceTypeId = s.ServiceTypeId,
                    ServiceTypeName = s.ServiceType.Name
                })
                .FirstOrDefaultAsync();
        }

        public async Task<ServiceTypeItemDto> CreateAsync(CreateServiceTypeItemDto dto)
        {
            var item = new ServiceTypeItem
            {
                Name = dto.Name,
                IsLocked = dto.IsLocked,
                SortOrder = dto.SortOrder,
                ServiceTypeId = dto.ServiceTypeId
            };

            _context.ServiceTypeItems.Add(item);
            await _context.SaveChangesAsync();

            var created = await GetByIdAsync(item.Id);
            return created!;
        }
    }
}
