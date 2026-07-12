using CarServiceCenter.Application.DTOs;
using CarServiceCenter.Domain.Entities;
using CarServiceCenter.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CarServiceCenter.Application.Services
{

    public class TechnitianService
    {
        private readonly AppDbContext _context;

        public TechnitianService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TechnitianDto>> GetAllAsync()
        {
            return await _context.Technitians
                .Select(t => new TechnitianDto
                {
                    Id = t.Id,
                    FirstName = t.FirstName,
                    LastName = t.LastName
                })
                .ToListAsync();
        }

        public async Task<TechnitianDto?> GetByIdAsync(int id)
        {
            return await _context.Technitians
                .Where(t => t.Id == id)
                .Select(t => new TechnitianDto
                {
                    Id = t.Id,
                    FirstName = t.FirstName,
                    LastName= t.LastName
                })
                .FirstOrDefaultAsync();
        }

        public async Task<TechnitianDto> CreateAsync(CreateTechnitianDto dto)
        {
            var technitian = new Technitian
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName
            };

            _context.Technitians.Add(technitian);
            await _context.SaveChangesAsync();

            return new TechnitianDto
            {
                Id = technitian.Id,
                FirstName = technitian.FirstName,
                LastName = technitian.LastName
            };
        }
    }
}
