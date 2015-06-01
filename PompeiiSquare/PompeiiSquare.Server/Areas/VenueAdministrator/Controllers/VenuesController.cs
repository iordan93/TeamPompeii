using AutoMapper;
using PompeiiSquare.Data.UnitOfWork;
using PompeiiSquare.Models;
using PompeiiSquare.Server.Areas.VenueAdministrator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            // TODO: return VenueShowModels
            var venuesFromDb = Data.Venues.All().ToList();
            return this.View(venuesFromDb);
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

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Venue venueFromDb = this.Data.Venues.Find(id);
            var venue = Mapper.Map<VenueEditBindingModel>(venueFromDb);

            if (venue == null)
            {
                return HttpNotFound();
            }

            ViewBag.Groups = this.Data.VenueGroups.All().Select(g => new VenueGroupBindingModel() { Id = g.Id, Name = g.Name }).ToList();
            return this.View(venue);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(VenueEditBindingModel model)
        {
            if (model.Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Venue venueFromDb = this.Data.Venues.Find(model.Id);
            venueFromDb.Name = model.Name;
            venueFromDb.Address = model.Address;
            venueFromDb.Contact = model.Contact;
            venueFromDb.Location = model.Location;
            venueFromDb.PriceTier = model.PriceTier;
            venueFromDb.Description = model.Description;
            this.Data.SaveChanges();

            return this.RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Venue venueFromDb = this.Data.Venues.Find(id);
            var venue = Mapper.Map<VenueDeleteBindingModel>(venueFromDb);


            if (venue == null)
            {
                return HttpNotFound();
            }

            return View(venue);
        }

        // POST: Venues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venue venue = this.Data.Venues.Find(id);
            this.Data.Venues.Remove(venue);
            this.Data.SaveChanges();
            return RedirectToAction("Index");
        }

        [ActionName("AddNewOpenHours")]
        public ActionResult AddNewOpenHours()
        {
            return this.PartialView();
        }

        [ActionName("AddNewGroup")]
        public ActionResult AddNewGroup()
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