namespace PompeiiSquare.Data 
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using PompeiiSquare.Models;
    using System.Data.Entity;

    public class PompeiiSquareDbContext : IdentityDbContext<User>
    {
        public PompeiiSquareDbContext()
            : base("PompeiiSquareConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Venue> Venues { get; set; }

        public IDbSet<Event> Events { get; set; }

        public IDbSet<Tag> Tags { get; set; }

        public IDbSet<VenueGroup> VenueGroups { get; set; }

        public IDbSet<EventCategory> EventCategories { get; set; }

        public IDbSet<Checkin> Checkins { get; set; }

        public IDbSet<Gender> Gender { get; set; }

        public IDbSet<Tip> Tips { get; set; }

        public IDbSet<OpenHours> OpenHours { get; set; }

        public IDbSet<Photo> Photos { get; set; }
        
        public static PompeiiSquareDbContext Create()
        {
            return new PompeiiSquareDbContext();
        }
    }
}