using PompeiiSquare.Data.UnitOfWork;
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

        [HttpPost, ActionName("Create")]
        public ActionResult Create(string name)
        {
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}