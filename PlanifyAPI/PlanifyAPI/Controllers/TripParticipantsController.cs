using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanifyAPI.Data.Context;
using PlanifyAPI.Models;

namespace PlanifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripParticipantsController : ControllerBase
    {
        private readonly PlanifyDbContext _context;

        public TripParticipantsController(PlanifyDbContext context)
        {
            _context = context;
        }

        // GET: api/tripparticipants/by-trip/5
        [HttpGet("by-trip/{tripId}")]
        public async Task<ActionResult<IEnumerable<TripParticipant>>> GetParticipants(int tripId)
        {
            return await _context.TripParticipants
                .Include(tp => tp.User)
                .Where(tp => tp.TripId == tripId)
                .ToListAsync();
        }

        // POST: api/tripparticipants/invite
        [HttpPost("invite")]
        public async Task<ActionResult<TripParticipant>> InviteUser([FromBody] TripParticipant invite)
        {
            invite.InvitedAt = DateTime.UtcNow;
            invite.IsConfirmed = false; // Not accepted yet

            _context.TripParticipants.Add(invite);
            await _context.SaveChangesAsync();

            return Ok(invite);
        }

        // PUT: api/tripparticipants/confirm/5
        [HttpPut("confirm/{participantId}")]
        public async Task<IActionResult> ConfirmInvitation(int participantId)
        {
            var participant = await _context.TripParticipants.FindAsync(participantId);

            if (participant == null)
                return NotFound();

            participant.IsConfirmed = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
