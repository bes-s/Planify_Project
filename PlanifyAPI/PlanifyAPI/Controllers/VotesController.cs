using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanifyAPI.Data.Context;
using PlanifyAPI.Models;

namespace PlanifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotesController : ControllerBase
    {
        private readonly PlanifyDbContext _context;

        public VotesController(PlanifyDbContext context)
        {
            _context = context;
        }

        // POST: api/votes/create
        [HttpPost("create")]
        public async Task<IActionResult> CreateVoteWithOptions([FromBody] Vote vote)
        {
            vote.CreatedAt = DateTime.UtcNow;
            _context.Votes.Add(vote);
            await _context.SaveChangesAsync();
            return Ok(vote);
        }

        // GET: api/votes/by-trip/5
        [HttpGet("by-trip/{tripId}")]
        public async Task<ActionResult<IEnumerable<Vote>>> GetVotes(int tripId)
        {
            return await _context.Votes
                .Where(v => v.TripId == tripId)
                .Include(v => v.Options)
                .ToListAsync();
        }

        // POST: api/votes/respond
        [HttpPost("respond")]
        public async Task<IActionResult> SubmitVote([FromBody] VoteResponse response)
        {
            _context.VoteResponses.Add(response);
            await _context.SaveChangesAsync();
            return Ok(response);
        }

        // GET: api/votes/responses/5
        [HttpGet("responses/{voteId}")]
        public async Task<ActionResult<IEnumerable<VoteResponse>>> GetResponses(int voteId)
        {
            return await _context.VoteResponses
                .Include(r => r.User)
                .Where(r => r.Option.VoteId == voteId)
                .ToListAsync();
        }
    }
}
