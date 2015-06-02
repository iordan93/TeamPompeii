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
    public class VenueGroupsController : BaseVenueAdministratorController
    {
        public VenueGroupsController(IPompeiiSquareData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.PartialView();
        }

        [HttpPost, ActionName("Create")]
        public ActionResult Create(VenueGroupBindingModel model)
        {
            if (ModelState.IsValid)
            {
                this.Data.VenueGroups.Add(new VenueGroup() { Name = model.Name });
                this.Data.SaveChanges();
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Group name must be at least 3 symbols long.");
        }
    }
}