using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PompeiiSquare.Models
{
    public class Tag
    {
        public Tag()
        {
            this.Venues = new HashSet<Venue>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Venue> Venues { get; set; }
    }
}
