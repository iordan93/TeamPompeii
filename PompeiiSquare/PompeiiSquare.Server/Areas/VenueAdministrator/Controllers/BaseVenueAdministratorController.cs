namespace PompeiiSquare.Server.Areas.VenueAdministrator.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Routing;
    using System.Web.Mvc;

    using PompeiiSquare.Models;
    using PompeiiSquare.Data.UnitOfWork;
    using PompeiiSquare.Server.Controllers;

    //[Authorize(Roles = "VenueAdministrator")]
    public abstract class BaseVenueAdministratorController : BaseController
    {
        protected BaseVenueAdministratorController(IPompeiiSquareData data)
            : base(data)
        {
        }

        protected BaseVenueAdministratorController(IPompeiiSquareData data, User userProfile)
            : base(data, userProfile)
        {
        }
    }
}