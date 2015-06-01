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
        public VenueCreateBindingModel()
        {
            this.OpenHours = new List<OpenHoursBindingModel>(1) { new OpenHoursBindingModel() };
        }

        [Required, MinLength(2, ErrorMessage = "The name must be at least 2 symbols long.")]
        public string Name { get; set; }

        [Required, MinLength(10, ErrorMessage = "The address must be at least 10 symbols long.")]
        public string Address { get; set; }

        [Required, MinLength(2, ErrorMessage = "The contact must be at least 2 symbols long.")]
        public string Contact { get; set; }

        public DbGeography Location { get; set; }

        [Range(0, 4), Display(Name = "Price tier")]
        public int PriceTier { get; set; }

        public IList<int> Groups { get; set; }

        [Display(Name = "Open hours")]
        public IList<OpenHoursBindingModel> OpenHours { get; set; }

        [DataType(DataType.MultilineText)]
        [Required, MinLength(10, ErrorMessage = "The description must be at least 10 symbols long.")]
        public string Description { get; set; }

        public string Tags { get; set; }

        // TODO: Add photo?
    }
}