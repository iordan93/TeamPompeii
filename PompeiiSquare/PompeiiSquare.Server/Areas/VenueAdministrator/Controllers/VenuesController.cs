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

        // GET: VenueAdministrator/Venues
        public ActionResult Index()
        {
            // TODO: Return list
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new VenueCreateBindingModel();
            return this.View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(VenueCreateBindingModel model)
        {
            var venue = Mapper.Map<Venue>(model);
            var tagNames = model.Tags
                .Split(new[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);
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

            venue.Tags = tags;
            venue.CreatedAt = DateTime.Now;
            this.Data.Venues.Add(venue);
            this.Data.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}