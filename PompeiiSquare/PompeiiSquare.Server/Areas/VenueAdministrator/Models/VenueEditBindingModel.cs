namespace PompeiiSquare.Server.Areas.VenueAdministrator.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity.Spatial;

    public class VenueEditBindingModel
    {
        public VenueEditBindingModel()
        {
            this.OpenHours = new List<OpenHoursBindingModel>(1) { new OpenHoursBindingModel() };
        }

        public int? Id { get; set; }

        [Required, MinLength(2, ErrorMessage = "The name must be at least 2 symbols long.")]
        public string Name { get; set; }

        [Required, MinLength(10, ErrorMessage = "The address must be at least 10 symbols long.")]
        public string Address { get; set; }

        [Required, MinLength(2, ErrorMessage = "The contact must be at least 2 symbols long.")]
        public string Contact { get; set; }

        public DbGeography Location { get; set; }

        [Range(0, 4)]
        public int PriceTier { get; set; }

        public IList<int> Groups { get; set; }

        [Display(Name = "Open hours")]
        public IList<OpenHoursBindingModel> OpenHours { get; set; }

        [Required, MinLength(10, ErrorMessage = "The description must be at least 10 symbols long.")]
        public string Description { get; set; }

        public string Tags { get; set; }

        // TODO: Add photo?
    }
}