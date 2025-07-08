using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanifyAPI.Data.Context;
using PlanifyAPI.Models;

namespace PlanifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly PlanifyDbContext _context;

        public TripsController(PlanifyDbContext context)
        {
            _context = context;
        }

        // GET: api/trips
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trip>>> GetTrips()
        {
            return await _context.Trips
                .Include(t => t.Organizer)
                .Include(t => t.Participants)
                .ToListAsync();
        }

        // GET: api/trips/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trip>> GetTrip(int id)
        {
            var trip = await _context.Trips
                .Include(t => t.Organizer)
                .Include(t => t.Participants)
                .FirstOrDefaultAsync(t => t.TripId == id);

            if (trip == null)
                return NotFound();

            return trip;
        }

        // POST: api/trips
        [HttpPost]
        public async Task<ActionResult<Trip>> CreateTrip(Trip trip)
        {
            trip.CreatedAt = DateTime.UtcNow;
            _context.Trips.Add(trip);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTrip), new { id = trip.TripId }, trip);
        }
    }
}
