namespace PompeiiSquare.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using PompeiiSquare.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<PompeiiSquare.Data.PompeiiSquareDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PompeiiSquare.Data.PompeiiSquareDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var adminRole = new IdentityRole { Name = "Admin" };
                var VenueAdminRole = new IdentityRole { Name = "VenueAdministrator" };
                var RegisteredUserRole = new IdentityRole { Name = "RegisteredUser" };
                var GuestRole = new IdentityRole { Name = "Guest" };

                manager.Create(adminRole);
                manager.Create(VenueAdminRole);
                manager.Create(RegisteredUserRole);
                manager.Create(GuestRole);
            }

            if (!context.Users.Any(u => u.UserName == "Founder"))
            {
                var male = new Gender { GenderName = "Male" };
                var female = new Gender { GenderName = "Female" };
                context.Gender.Add(male);
                context.Gender.Add(female);

                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var founder = new User
                {
                    UserName = "Founder",
                    FirstName = "Pesho",
                    LastName = "Peshov",
                    Email = "pesho@softuni.bg",
                    HomeCity = "Rousse",
                    Gender = male
                };

                var venueAdmin = new User
                {
                    UserName = "Gosho",
                    FirstName = "Georgi",
                    LastName = "Goshov",
                    Email = "gosho@softuni.bg",
                    HomeCity = "Sofia",
                    Gender = male
                };

                manager.Create(founder, "adminPassword");
                manager.AddToRole(founder.Id, "Admin");
                manager.Create(venueAdmin, "venueAdminPassword");
                manager.AddToRole(venueAdmin.Id, "VenueAdministrator");
            }

            if (!context.VenueGroups.Any())
            {
                var drinks = new VenueGroup { Name = "Drinks" };
                var food = new VenueGroup { Name = "Food" };
                var fun = new VenueGroup { Name = "Fun" };
                var nightlife = new VenueGroup { Name = "Nightlife" };
                var shopping = new VenueGroup { Name = "Shopping" };
                context.VenueGroups.Add(drinks);
                context.VenueGroups.Add(food);
                context.VenueGroups.Add(fun);
                context.VenueGroups.Add(nightlife);
                context.VenueGroups.Add(shopping);
            }

            if (!context.Tags.Any())
            {
                var party = new Tag { Name = "Party" };
                var relax = new Tag { Name = "Relax" };
                var cheap = new Tag { Name = "Cheap" };
                context.Tags.Add(party);
                context.Tags.Add(relax);
                context.Tags.Add(cheap);
            }

            //TODO : Add more seed data and Update admin passwords
        }
    }
}
