namespace PlanifyAPI.Models
{
  public  class Booking
    {
        public int BookingId { get; set; }
        public int TripId { get; set; }
        public string BookingType { get; set; } = string.Empty; // Hotel, Flight, Bus, Ferry
        public string Provider { get; set; } = string.Empty;
        public string BookingLink { get; set; } = string.Empty;
        public DateTime BookedAt { get; set; }

        public Trip Trip { get; set; }
    }
}
