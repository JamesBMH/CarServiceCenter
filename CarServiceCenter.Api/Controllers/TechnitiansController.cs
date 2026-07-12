using CarServiceCenter.Application.DTOs;
using CarServiceCenter.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceCenter.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TechnitiansController : ControllerBase
    {
        private readonly TechnitianService _technitianService;

        public TechnitiansController(TechnitianService technicianService)
        {
            _technitianService = technicianService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TechnitianDto>>> GetAll()
        {
            var technicians = await _technitianService.GetAllAsync();

            return Ok(technicians);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TechnitianDto>> GetById(int id)
        {
            var technitian = await _technitianService.GetByIdAsync(id);

            if (technitian is null) return NotFound();

            return Ok(technitian);
        }

        [HttpPost]
        public async Task<ActionResult<TechnitianDto>> Create(CreateTechnitianDto dto)
        {
            var technitian = await _technitianService.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = technitian.Id }, technitian);
        }
    }
}
