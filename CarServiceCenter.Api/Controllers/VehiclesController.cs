using CarServiceCenter.Application.DTOs;
using CarServiceCenter.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceCenter.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly VehicleService _vehicleService;

        public VehiclesController(VehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public async Task<ActionResult<List<VehicleDto>>> GetAll()
        {
            var vehicles = await _vehicleService.GetAllAsync();

            return Ok(vehicles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleDto>> GetById(int id)
        {
            var vehicle = await _vehicleService.GetByIdAsync(id);

            if (vehicle is null) return NotFound();

            return Ok(vehicle);
        }

        [HttpPost]
        public async Task<ActionResult<VehicleDto>> Create(CreateVehicleDto dto)
        {
            var vehicle = await _vehicleService.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = vehicle.Id }, vehicle);
        }
    }
}
