using PompeiiSquare.Data.UnitOfWork;
using PompeiiSquare.Models;
using PompeiiSquare.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PompeiiSquare.Server.Controllers
{
    public class VenuesController : BaseController
    {
        public VenuesController(IPompeiiSquareData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var venuesFromDb = Data.Venues.All().ToList();
            return this.View(venuesFromDb);
        }

        [HttpGet]
        public ActionResult SearchByGroup(string id)
        {
            var groupFromDb = this.Data.VenueGroups.All().Where(g => g.Name == id);
            var venuesFromDb = Data.Venues.All().Where(v => v.Groups.Any(g => g.Name == id)).ToList();
            return this.View("Index", venuesFromDb);
        }

        [HttpGet]
        public ActionResult ViewDetails(int id)
        {
            var venueFromDb = this.Data.Venues.Find(id);
            return this.View(venueFromDb);
        }

        public ActionResult Like(int id)
        {
            Venue venue = this.Data.Venues.Find(id);
            venue.Likes++;
            this.Data.SaveChanges();
            return this.PartialView("_VenueDetails", venue);
        }

        public ActionResult Dislike(int id)
        {
            Venue venue = this.Data.Venues.Find(id);
            venue.Likes--;
            this.Data.SaveChanges();
            return this.PartialView("_VenueDetails", venue);
        }

        [HttpGet]
        public ActionResult Checkin(int id)
        {
            var venue = this.Data.Venues.Find(id);
            if (venue == null)
            {
                return this.HttpNotFound();
            }

            var model = new CheckinBindingModel() { VenueId = venue.Id, VenueName = venue.Name };
            return this.View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Checkin(CheckinBindingModel model)
        {
            var venue = this.Data.Venues.Find(model.VenueId);
            if (venue == null)
            {
                return this.HttpNotFound();
            }

            var checkin = new Checkin()
            {
                Venue = venue,
                VenueId = venue.Id,
                CreatedAt = DateTime.Now,
                User = this.UserProfile
            };

            this.Data.Checkins.Add(checkin);
            this.Data.SaveChanges();
            return this.RedirectToAction("ViewDetails", new { id = model.VenueId });
        }
    }
}