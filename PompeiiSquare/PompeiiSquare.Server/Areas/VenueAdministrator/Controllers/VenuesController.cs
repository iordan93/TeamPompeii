using AutoMapper;
using PompeiiSquare.Data.UnitOfWork;
using PompeiiSquare.Models;
using PompeiiSquare.Server.Areas.VenueAdministrator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PompeiiSquare.Server.Areas.VenueAdministrator.Controllers
{
    public class VenuesController : BaseVenueAdministratorController
    {
        public VenuesController(IPompeiiSquareData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            // TODO: Return list
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new VenueCreateBindingModel();
            ViewBag.Groups = this.Data.VenueGroups.All().Select(g => new VenueGroupBindingModel() { Id = g.Id, Name = g.Name }).ToList();
            return this.View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(VenueCreateBindingModel model)
        {
            var venue = Mapper.Map<Venue>(model);
            var openHours = venue.OpenHours;
            venue.OpenHours = null;
            var tagNames = model.Tags
                .Split(new[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);
            var tags = MapTags(tagNames);

            var groups = MapGroups(model.Groups);

            venue.Tags = tags;
            venue.Groups = groups;
            venue.CreatedAt = DateTime.Now;
            this.Data.Venues.Add(venue);
            this.Data.SaveChanges();

            venue.OpenHours = openHours;
            this.Data.SaveChanges();
            return RedirectToAction("Index");
        }

        [ActionName("AddNewOpenHours")]
        public ActionResult AddNewOpenHours()
        {
            return this.PartialView();
        }

        [NonAction]
        private List<Tag> MapTags(string[] tagNames)
        {
            var tags = new List<Tag>();
            foreach (var tagName in tagNames)
            {
                var tag = this.Data.Tags.All().FirstOrDefault(t => t.Name == tagName);
                if (tag == null)
                {
                    tag = this.Data.Tags.Add(new Tag() { Name = tagName });
                    this.Data.SaveChanges();
                }

                tags.Add(tag);
            }

            return tags;
        }

        [NonAction]
        private List<VenueGroup> MapGroups(IList<int> modelGroups)
        {
            var groups = new List<VenueGroup>();
            foreach (var group in modelGroups)
            {
                var groupFromDb = this.Data.VenueGroups.Find(group);
                if (groupFromDb != null)
                {
                    groups.Add(groupFromDb);
                }
            }

            return groups;
        }
    }
}