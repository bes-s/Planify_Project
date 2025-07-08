namespace PlanifyAPI.Models { 
public class Itinerary
{
    public int ItineraryId { get; set; }
    public int TripId { get; set; }
    public DateTime Date { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;

    public Trip Trip { get; set; }
}
}