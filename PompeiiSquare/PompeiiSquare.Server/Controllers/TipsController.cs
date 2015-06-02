namespace PompeiiSquare.Server.Controllers
{
    using PompeiiSquare.Data.UnitOfWork;
    using PompeiiSquare.Server.Models;
    using System.Net;
    using System.Web.Mvc;

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
                // Save Tip to DB
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }

            return Content(""); // TODO: Redirect
        }
    }
}