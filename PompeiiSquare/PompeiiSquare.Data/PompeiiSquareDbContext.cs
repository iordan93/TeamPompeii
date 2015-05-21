namespace PompeiiSquare.Data 
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using PompeiiSquare.Models;

    public class PompeiiSquareDbContext : IdentityDbContext<User>
    {
        public PompeiiSquareDbContext()
            : base("PompeiiSquareConnection", throwIfV1Schema: false)
        {
        }

        public static PompeiiSquareDbContext Create()
        {
            return new PompeiiSquareDbContext();
        }
    }
}