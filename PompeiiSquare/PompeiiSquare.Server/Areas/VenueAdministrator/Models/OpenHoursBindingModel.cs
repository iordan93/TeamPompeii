using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace PompeiiSquare.Server.Areas.VenueAdministrator.Models
{
    public class OpenHoursBindingModel
    {
        public string Weekday { get; set; }

        [RegularExpression(@"^(\d{1,2}:\d{2}\s*-\s*\d{1,2}:\d{2})$", ErrorMessage = "Invalid hours input. The input must be in format: 00:00 - 24:00")]
        public string Hours { get; set; }
    }
}
