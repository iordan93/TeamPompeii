using PompeiiSquare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PompeiiSquare.Server.Models
{
    public class CheckinBindingModel
    {
        public int VenueId { get; set; }

        public string VenueName { get; set; }

        public HttpPostedFileBase Photo { get; set; }
    }
}