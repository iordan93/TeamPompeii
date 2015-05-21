using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PompeiiSquare.Models
{
    public class EventCategory
    {
        public EventCategory()
        {
            this.Events = new HashSet<Event>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
