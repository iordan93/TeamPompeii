namespace PompeiiSquare.Server.Areas.VenueAdministrator.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity.Spatial;

    public class VenueDeleteBindingModel
    {
        public VenueDeleteBindingModel()
        {
            this.OpenHours = new List<OpenHoursBindingModel>(1) { new OpenHoursBindingModel() };
        }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Contact { get; set; }

        public DbGeography Location { get; set; }

        [Range(0, 4)]
        public int PriceTier { get; set; }

        public IList<int> Groups { get; set; }

        [Display(Name = "Open hours")]
        public IList<OpenHoursBindingModel> OpenHours { get; set; }

        public string Description { get; set; }

        public string Tags { get; set; }

        // TODO: Add photo?
    }
}