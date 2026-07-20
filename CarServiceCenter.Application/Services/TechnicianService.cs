using CarServiceCenter.Application.DTOs;
using CarServiceCenter.Domain.Entities;
using CarServiceCenter.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CarServiceCenter.Application.Services
{

    public class TechnicianService
    {
        private readonly AppDbContext _context;

        public TechnicianService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TechnicianDto>> GetAllAsync()
        {
            return await _context.Technicians
                .Select(t => new TechnicianDto
                {
                    Id = t.Id,
                    FirstName = t.FirstName,
                    LastName = t.LastName
                })
                .ToListAsync();
        }

        public async Task<TechnicianDto?> GetByIdAsync(int id)
        {
            return await _context.Technicians
                .Where(t => t.Id == id)
                .Select(t => new TechnicianDto
                {
                    Id = t.Id,
                    FirstName = t.FirstName,
                    LastName= t.LastName
                })
                .FirstOrDefaultAsync();
        }

        public async Task<TechnicianDto> CreateAsync(CreateTechnicianDto dto)
        {
            var technitian = new Technician
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName
            };

            _context.Technicians.Add(technitian);
            await _context.SaveChangesAsync();

            return new TechnicianDto
            {
                Id = technitian.Id,
                FirstName = technitian.FirstName,
                LastName = technitian.LastName
            };
        }
    }
}
