namespace PlanifyAPI.Models { 
public class User
{
    public int UserId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    public ICollection<Trip> OrganizedTrips { get; set; }
    public ICollection<TripParticipant> Participations { get; set; }
}
}