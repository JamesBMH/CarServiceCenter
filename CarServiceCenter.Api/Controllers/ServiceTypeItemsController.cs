using CarServiceCenter.Application.DTOs;
using CarServiceCenter.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceCenter.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceTypeItemsController : ControllerBase
    {
        private readonly ServiceTypeItemService _serviceTypeItemService;

        public ServiceTypeItemsController(ServiceTypeItemService serviceTypeItemService)
        {
            _serviceTypeItemService = serviceTypeItemService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ServiceTypeItemDto>>> GetAll()
        {
            var items = await _serviceTypeItemService.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceTypeItemDto>> GetById(int id)
        {
            var item = await _serviceTypeItemService.GetByIdAsync(id);
            if (item is null) return NotFound();
            return Ok(item);
        }

        [HttpGet("by-service-type/{serviceTypeId}")]
        public async Task<ActionResult<List<ServiceTypeItemDto>>> GetByServiceType(int serviceTypeId)
        {
            var items = await _serviceTypeItemService.GetByServiceTypeAsync(serviceTypeId);
            return Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceTypeItemDto>> Create(CreateServiceTypeItemDto dto)
        {
            var item = await _serviceTypeItemService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }
    }
}
