using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PompeiiSquare.Server.Models
{
    public class TipBindingModel
    {
        public int Id { get; set; }

        public int venueId { get; set; }

        [Required, MinLength(3, ErrorMessage = "The tip text must be at least 3 symbols long")]
        public string Content { get; set; }

        public HttpPostedFileBase Photo { get; set; }
    }
}