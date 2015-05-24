namespace PompeiiSquare.Models 
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class User : IdentityUser
    {
        public User()
        {
            this.Photos = new HashSet<Photo>();
            this.Tips = new HashSet<Tip>();
            this.Checkins = new HashSet<Checkin>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string HomeCity { get; set; }

        public Gender Gender { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }

        public virtual Photo ProfilePicture { get; set; }
        
        public virtual ICollection<Tip> Tips { get; set; }

        public virtual ICollection<Checkin> Checkins { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}