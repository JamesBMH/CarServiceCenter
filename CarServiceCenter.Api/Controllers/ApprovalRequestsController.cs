using CarServiceCenter.Application.DTOs;
using CarServiceCenter.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceCenter.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApprovalRequestsController : ControllerBase
    {
        private readonly ApprovalRequestService _approvalRequestService;

        public ApprovalRequestsController(ApprovalRequestService approvalRequestService)
        {
            _approvalRequestService = approvalRequestService;
        }

        [HttpGet("by-booking/{bookingId}")]
        public async Task<ActionResult<List<ApprovalRequestDto>>> GetByBooking(int bookingId)
        {
            var requests = await _approvalRequestService.GetByBookingAsync(bookingId);
            return Ok(requests);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApprovalRequestDto>> GetById(int id)
        {
            var request = await _approvalRequestService.GetByIdAsync(id);
            if (request is null) return NotFound();
            return Ok(request);
        }

        [HttpPost]
        public async Task<ActionResult<ApprovalRequestDto>> Create(CreateApprovalRequestDto dto)
        {
            var request = await _approvalRequestService.CreatedAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = request.Id }, request);
        }
    }
}
