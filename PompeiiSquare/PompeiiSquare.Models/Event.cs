using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PompeiiSquare.Models
{
    public class Event
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual EventCategory Category { get; set; }

        public virtual Venue Venue { get; set; }

        public DateTime StartsAt { get; set; }

        public DateTime EndsAt { get; set; }

        public int Likes { get; set; }
    }
}
