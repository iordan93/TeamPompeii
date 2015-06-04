using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PompeiiSquare.Server.Models
{
    public class TipBindingModel
    {
        public int venueId { get; set; }

        public string Content { get; set; }

        public HttpPostedFileBase Photo { get; set; }
    }
}