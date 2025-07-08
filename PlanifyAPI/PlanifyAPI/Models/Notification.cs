namespace PlanifyAPI.Models { 
public class Notification
{
    public int NotificationId { get; set; }
    public int UserId { get; set; }
    public int? TripId { get; set; } // nullable
    public string Content { get; set; } = string.Empty;
    public bool IsRead { get; set; }
    public DateTime SentAt { get; set; }

    public User User { get; set; }
    public Trip? Trip { get; set; }
}
}