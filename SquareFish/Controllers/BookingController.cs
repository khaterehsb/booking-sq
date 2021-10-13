using Microsoft.AspNetCore.Mvc;
using SquareFish.Application;
using SquareFish.Application.ViewModels;
using SquareFish.Core;
using System;
using System.Threading.Tasks;

namespace SquareFish.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> create([FromBody] CreateBooking createBooking)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _bookingService.Create(createBooking.Price, createBooking.StartDate, createBooking.Name, createBooking.Leaders, createBooking.Currency);
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> update([FromBody] UpdateBooking updateBooking)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _bookingService.Update(updateBooking.Id, updateBooking.Price, updateBooking.StartDate, updateBooking.Name, updateBooking.Status, updateBooking.Currency);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> delete(int Id)
        => Ok(await _bookingService.Delete(Id));

        [HttpGet("{page}/{result}")]
        public async Task<IActionResult> Get(int page, int result, [FromQuery] DateTime? startDate, [FromQuery] int? status)
        {
            return Ok(await _bookingService.Get(result, page, startDate, status));
        }

    }
}
