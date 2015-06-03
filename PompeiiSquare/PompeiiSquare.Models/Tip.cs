using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PompeiiSquare.Models
{
    public class Tip
    {
        //[Key, Column(Order = 4)]
        //public int Id { get; set; }

        [Key, Column(Order = 0)]
        public int UserId { get; set; }

        [Key, Column(Order = 1)]
        public int VenueId { get; set; }

        [Key, Column(Order = 2)]
        public DateTime CreatedAt { get; set; }

        public virtual User User { get; set; }

        public virtual Venue Venue { get; set; }

        public string Text { get; set; }

        public virtual Photo Photo { get; set; }

        public int Likes { get; set; }
    }
}
