namespace PlanifyAPI.Models { 
public class Comment
{
    public int CommentId { get; set; }
    public int TripId { get; set; }
    public int UserId { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    public Trip Trip { get; set; }
    public User User { get; set; }
}
}