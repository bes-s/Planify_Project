using Microsoft.EntityFrameworkCore;
using PlanifyAPI.Models;

namespace PlanifyAPI.Data.Context
{
    public class PlanifyDbContext : DbContext
    {
        public PlanifyDbContext(DbContextOptions<PlanifyDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<TripParticipant> TripParticipants { get; set; }
        public DbSet<Itinerary> Itineraries { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<VoteOption> VoteOptions { get; set; }
        public DbSet<VoteResponse> VoteResponses { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Avoid multiple cascade paths by disabling one of them
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Prevent cascade delete: TripParticipants → Users
            modelBuilder.Entity<TripParticipant>()
                .HasOne(tp => tp.User)
                .WithMany()
                .HasForeignKey(tp => tp.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Prevent cascade delete: VoteResponses → VoteOptions
            modelBuilder.Entity<VoteResponse>()
                .HasOne(vr => vr.Option)
                .WithMany()
                .HasForeignKey(vr => vr.OptionId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
