namespace PompeiiSquare.Data.UnitOfWork
{
    using PompeiiSquare.Data.Repositories;
    using PompeiiSquare.Models;

    public interface IPompeiiSquareData
    {
        IRepository<User> Users { get; }

        IRepository<Gender> Genders { get; }
        
        IRepository<Venue> Venues { get; }
        
        IRepository<VenueGroup> VenueGroups { get; }
        
        IRepository<OpenHours> OpenHours { get; }
        
        IRepository<Tag> Tags { get; }
        
        IRepository<Photo> Photos { get; }
        
        IRepository<Tip> Tips { get; }
        
        IRepository<Checkin> Checkins { get; }
        
        IRepository<Notification> Notifications { get; }
        
        IRepository<Event> Events { get; }
        
        IRepository<EventCategory> EventCategories { get; }
        
        void SaveChanges();
    }
}
