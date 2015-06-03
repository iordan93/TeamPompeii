using PompeiiSquare.Data.UnitOfWork;
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
    }
}