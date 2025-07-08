namespace PlanifyAPI.Models { 
public class Vote
{
    public int VoteId { get; set; }
    public int TripId { get; set; }
    public string Question { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    public Trip Trip { get; set; }
    public ICollection<VoteOption> Options { get; set; }
}
}