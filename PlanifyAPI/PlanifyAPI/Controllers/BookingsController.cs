using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanifyAPI.Data.Context;
using PlanifyAPI.Models;

namespace PlanifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly PlanifyDbContext _context;

        public BookingsController(PlanifyDbContext context)
        {
            _context = context;
        }

        // GET: api/bookings/by-trip/5
        [HttpGet("by-trip/{tripId}")]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookingsForTrip(int tripId)
        {
            return await _context.Bookings
                .Where(b => b.TripId == tripId)
                .OrderBy(b => b.BookedAt)
                .ToListAsync();
        }

        // POST: api/bookings
        [HttpPost]
        public async Task<ActionResult<Booking>> AddBooking(Booking booking)
        {
            booking.BookedAt = DateTime.UtcNow;
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBookingsForTrip), new { tripId = booking.TripId }, booking);
        }
    }
}
