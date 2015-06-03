namespace PompeiiSquare.Server.Controllers
{
    using PompeiiSquare.Data.UnitOfWork;
    using PompeiiSquare.Server.Models;
    using System.Net;
    using System.Web.Mvc;
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

                return this.RedirectToAction("ViewDetails", "Venues", routeValues: new { id = model.venueId });
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid model");
        }

        public ActionResult Like(int id)
        {
            var tip = this.Data.Tips.Find(id);
            tip.Likes++;
            this.Data.SaveChanges();
            return this.PartialView("_TipDetails", tip);
        }

        public ActionResult Dislike(int id)
        {
            var tip = this.Data.Tips.Find(id);
            tip.Likes--;
            this.Data.SaveChanges();
            return this.PartialView("_TipDetails", tip);
        }
    }
}