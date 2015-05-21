using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PompeiiSquare.Models
{
    public class OpenHours
    {
        public int Id { get; set; }

        public int VenueId { get; set; }

        public string Weekday { get; set; }

        public string Hours { get; set; }
    }
}
