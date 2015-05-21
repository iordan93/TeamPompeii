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
        [Key, Column(Order = 0)]
        public int UserId { get; set; }

        [Key, Column(Order = 1)]
        public int VenueId { get; set; }

        [Key, Column(Order = 2)]
        public DateTime CreatedAt { get; set; }

        public virtual User User { get; set; }

        public virtual Venue Venue { get; set; }

        public virtual Photo Photo { get; set; }
    }
}
