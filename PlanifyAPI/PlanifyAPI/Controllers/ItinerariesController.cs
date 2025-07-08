using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanifyAPI.Data.Context;
using PlanifyAPI.Models;

namespace PlanifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItinerariesController : ControllerBase
    {
        private readonly PlanifyDbContext _context;

        public ItinerariesController(PlanifyDbContext context)
        {
            _context = context;
        }

        // GET: api/itineraries/by-trip/5
        [HttpGet("by-trip/{tripId}")]
        public async Task<ActionResult<IEnumerable<Itinerary>>> GetItinerary(int tripId)
        {
            return await _context.Itineraries
                .Where(i => i.TripId == tripId)
                .OrderBy(i => i.Date)
                .ToListAsync();
        }

        // POST: api/itineraries
        [HttpPost]
        public async Task<ActionResult<Itinerary>> AddItinerary(Itinerary itinerary)
        {
            _context.Itineraries.Add(itinerary);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItinerary), new { tripId = itinerary.TripId }, itinerary);
        }
    }
}
