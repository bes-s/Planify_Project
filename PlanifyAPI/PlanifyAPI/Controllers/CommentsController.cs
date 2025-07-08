using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanifyAPI.Data.Context;
using PlanifyAPI.Models;

namespace PlanifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly PlanifyDbContext _context;

        public CommentsController(PlanifyDbContext context)
        {
            _context = context;
        }

        // GET: api/comments/by-trip/5
        [HttpGet("by-trip/{tripId}")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetCommentsForTrip(int tripId)
        {
            return await _context.Comments
                .Where(c => c.TripId == tripId)
                .Include(c => c.User)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();
        }

        // POST: api/comments
        [HttpPost]
        public async Task<ActionResult<Comment>> AddComment(Comment comment)
        {
            comment.CreatedAt = DateTime.UtcNow;
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCommentsForTrip), new { tripId = comment.TripId }, comment);
        }
    }
}
