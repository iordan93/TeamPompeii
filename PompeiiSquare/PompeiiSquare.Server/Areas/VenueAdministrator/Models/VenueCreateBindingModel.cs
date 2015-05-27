using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;

namespace PompeiiSquare.Server.Areas.VenueAdministrator.Models
{
    public class VenueCreateBindingModel
    {
        [Required, MinLength(2, ErrorMessage = "The name must be at least 2 symbols long.")]
        public string Name { get; set; }

        [Required, MinLength(10, ErrorMessage = "The address must be at least 10 symbols long.")]
        public string Address { get; set; }

        [Required, MinLength(2, ErrorMessage = "The contact must be at least 2 symbols long.")]
        public string Contact { get; set; }

        public DbGeography Location { get; set; }

        [Range(1, 4)]
        public int PriceTier { get; set; }

        public IList<string> Groups { get; set; }

        public IList<OpenHoursBindingModel> OpenHours { get; set; }

        [Required, MinLength(10, ErrorMessage = "The description must be at least 10 symbols long.")]
        public string Description { get; set; }

        public string Tags { get; set; }

        // TODO: Add photo?
    }
}