namespace PompeiiSquare.Server.Areas.VenueAdministrator.Models
{
    using PompeiiSquare.Models;

    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Spatial;

    public class VenueShowBindingModel
    {
        public VenueShowBindingModel()
        {
            this.Groups = new HashSet<VenueGroup>();
            this.OpenHours = new HashSet<OpenHours>();
            this.Checkins = new HashSet<Checkin>();
            this.Tags = new HashSet<Tag>();
            this.Tips = new HashSet<Tip>();
            this.Events = new HashSet<Event>();           
        }


        public string Name { get; set; }

        public string Address { get; set; }

        public string Contact { get; set; }

        public DbGeography Location { get; set; }

        public int PriceTier { get; set; }

        public virtual ICollection<VenueGroup> Groups { get; set; }

        public virtual ICollection<OpenHours> OpenHours { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Checkin> Checkins { get; set; }
        
        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<Tip> Tips { get; set; }

        public virtual ICollection<Event> Events { get; set; }

        public virtual Photo Photo { get; set; }

        public int Likes { get; set; }
    }
}