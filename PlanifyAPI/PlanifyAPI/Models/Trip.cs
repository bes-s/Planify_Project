namespace PlanifyAPI.Models { 
public class Trip
{
    public int TripId { get; set; }
    public int OrganizerUserId { get; set; }
    public string TripName { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    public User Organizer { get; set; }
    public ICollection<TripParticipant> Participants { get; set; }
    public ICollection<Itinerary> Itineraries { get; set; }
    public ICollection<Booking> Bookings { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<Vote> Votes { get; set; }
}
}