using PompeiiSquare.Data.UnitOfWork;
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
            return this.View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(VenueCreateBindingModel model)
        {
            throw new NotImplementedException();
        }
    }
}