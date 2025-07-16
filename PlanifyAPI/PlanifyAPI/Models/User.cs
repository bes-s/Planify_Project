using Microsoft.AspNetCore.Identity;

namespace PlanifyAPI.Models { 
public class User : IdentityUser
{
    public DateTime CreatedAt { get; set; }

    public ICollection<Trip> OrganizedTrips { get; set; }
    public ICollection<TripParticipant> Participations { get; set; }
}
}