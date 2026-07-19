using CarServiceCenter.Application.DTOs;
using CarServiceCenter.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceCenter.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingServiceItemsController : ControllerBase
    {
        private readonly BookingServiceItemService _bookingServiceItemService;

        public BookingServiceItemsController(BookingServiceItemService bookingServiceItemService)
        {
            _bookingServiceItemService = bookingServiceItemService;
        }

        [HttpGet("by-booking/{bookingId}")]
        public async Task<ActionResult<List<BookingServiceItemDto>>> GetByBooking(int bookingId)
        {
            var items = await _bookingServiceItemService.GetByBookingAsync(bookingId);
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookingServiceItemDto>> GetById(int id)
        {
            var item = await _bookingServiceItemService.GetByIdAsync(id);
            if (item is null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<BookingServiceItemDto>> Create(CreateBookingServiceItemDto dto)
        {
            var item = await _bookingServiceItemService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }
    }
}
