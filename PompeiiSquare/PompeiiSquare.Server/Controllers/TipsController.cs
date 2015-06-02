namespace PompeiiSquare.Server.Controllers
{
    using PompeiiSquare.Data.UnitOfWork;
    using PompeiiSquare.Server.Models;
    using System.Net;
    using System.Web.Mvc;
    using System.Linq;
    using PompeiiSquare.Models;
    using System;

    public class TipsController : BaseController
    {
        public TipsController(IPompeiiSquareData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.PartialView();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(TipBindingModel model)
        {
            if (ModelState.IsValid)
            {
                //var venueFromDb = this.Data.Venues.All().Where(v => v.Id == model.venueId);
                var tip = new Tip()
                {
                    Text = model.Content,
                    Likes = 0,
                    CreatedAt = DateTime.Now,
                    User = this.UserProfile,
                    VenueId = model.venueId
                };
                this.Data.Tips.Add(tip);
                this.Data.SaveChanges();

                return this.RedirectToAction("ViewDetails", "Venues", routeValues: new { id = model.venueId , area = "VenueAdministrator"});
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid model");
        }
    }
}