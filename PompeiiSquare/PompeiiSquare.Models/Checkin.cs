using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PompeiiSquare.Models
{
    public class Checkin
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int VenueId { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual User User { get; set; }

        public virtual Venue Venue { get; set; }

        public virtual Photo Photo { get; set; }
    }
}
