using CarServiceCenter.Application.DTOs;
using CarServiceCenter.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceCenter.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TechniciansController : ControllerBase
    {
        private readonly TechnicianService _technicianService;

        public TechniciansController(TechnicianService technicianService)
        {
            _technicianService = technicianService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TechnicianDto>>> GetAll()
        {
            var technicians = await _technicianService.GetAllAsync();

            return Ok(technicians);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TechnicianDto>> GetById(int id)
        {
            var technician = await _technicianService.GetByIdAsync(id);

            if (technician is null) return NotFound();

            return Ok(technician);
        }

        [HttpPost]
        public async Task<ActionResult<TechnicianDto>> Create(CreateTechnicianDto dto)
        {
            var technician = await _technicianService.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = technician.Id }, technician);
        }
    }
}
