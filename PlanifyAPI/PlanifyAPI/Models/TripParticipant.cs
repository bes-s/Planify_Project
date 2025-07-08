using System;
using System.ComponentModel.DataAnnotations;

namespace PlanifyAPI.Models
{
    public class TripParticipant
    {
        [Key] 
        public int ParticipantId { get; set; }

        public int TripId { get; set; }
        public int UserId { get; set; }
        public bool IsConfirmed { get; set; }
        public DateTime InvitedAt { get; set; }

        public Trip Trip { get; set; }
        public User User { get; set; }
    }
}
