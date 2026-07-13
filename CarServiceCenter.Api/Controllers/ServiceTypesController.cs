using CarServiceCenter.Application.DTOs;
using CarServiceCenter.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceCenter.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceTypesController : ControllerBase
    {
        private readonly ServiceTypeService _serviceTypeService;

        public ServiceTypesController(ServiceTypeService serviceTypeService)
        {
            _serviceTypeService = serviceTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ServiceTypeDto>>> GetAll()
        {
            var serviceTypes = await _serviceTypeService.GetAllAsync();

            return Ok(serviceTypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceTypeDto>> GetById(int id)
        {
            var serviceType = await _serviceTypeService.GetByIdAsync(id);

            if (serviceType is null) return NotFound();

            return Ok(serviceType);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceTypeDto>> Create(CreateServiceTypeDto dto)
        {
            var serviceType = await _serviceTypeService.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = serviceType.Id }, serviceType);
        }
    }
}
