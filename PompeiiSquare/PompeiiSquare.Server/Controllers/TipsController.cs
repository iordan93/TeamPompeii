namespace PompeiiSquare.Server.Controllers
{
    using PompeiiSquare.Data.UnitOfWork;
    using PompeiiSquare.Server.Models;
    using System.Net;
    using System.Web.Mvc;
    using PompeiiSquare.Models;
    using System;
    using PompeiiSquare.Server.Utilities;

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

                if (model.Photo != null)
                {
                    string path = DropboxRepository.Upload(model.Photo.FileName, this.UserProfile.UserName, model.Photo.InputStream);
                    var photo = new Photo() { Path = path, Author = this.UserProfile, CreatedAt = DateTime.Now };
                    tip.Photo = photo;
                    this.Data.Tips.Add(tip);
                    this.Data.SaveChanges();
                }

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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var tip = this.Data.Tips.Find(id);
            if (tip == null)
            {
                return HttpNotFound();
            }

            if (tip.User != this.UserProfile)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "You cannot edit a tip which is not yours.");
            }

            return View(new TipBindingModel() { Id = tip.Id, Content = tip.Text, venueId = tip.VenueId });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Update(TipBindingModel model)
        {
            var tipDb = this.Data.Tips.Find(model.Id);
            if (tipDb == null)
            {
                return HttpNotFound();
            }

            if (tipDb.User != this.UserProfile)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "You cannot edit a tip which is not yours.");
            }

            tipDb.Text = model.Content;
            this.Data.SaveChanges();

            if (model.Photo != null)
            {
                var path = DropboxRepository.Upload(model.Photo.FileName, this.UserProfile.UserName, model.Photo.InputStream);
                var photo = new Photo() { Path = path, Author = this.UserProfile, CreatedAt = DateTime.Now };
                tipDb.Photo = photo;
                this.Data.SaveChanges();
            }

            return RedirectToAction("ViewDetails", "Venues", new { id = model.venueId });
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var tip = this.Data.Tips.Find(id);
            if (tip == null)
            {
                return HttpNotFound();
            }

            if (tip.User != this.UserProfile)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "You cannot delete a tip which is not yours.");
            }

            return View(new TipBindingModel() { Id = tip.Id, Content = tip.Text, venueId = tip.VenueId });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Remove(TipBindingModel model)
        {
            var tipDb = this.Data.Tips.Find(model.Id);
            if (tipDb == null)
            {
                return HttpNotFound();
            }

            if (tipDb.User != this.UserProfile)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "You cannot edit a tip which is not yours.");
            }

            this.Data.Tips.Remove(model.Id);
            this.Data.SaveChanges();

            return RedirectToAction("ViewDetails", "Venues", new { id = model.venueId });
        }
    }
}