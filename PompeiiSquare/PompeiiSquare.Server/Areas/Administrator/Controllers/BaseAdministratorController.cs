namespace PompeiiSquare.Server.Areas.Administrator.Controllers
{
    using PompeiiSquare.Data.UnitOfWork;
    using PompeiiSquare.Models;
    using PompeiiSquare.Server.Controllers;
    using System.Web.Mvc;

    [Authorize(Roles = "Admin")]
    public class BaseAdministratorController : BaseController
    {
        protected BaseAdministratorController(IPompeiiSquareData data)
            : base(data)
        {
        }

        protected BaseAdministratorController(IPompeiiSquareData data, User userProfile)
            : base(data, userProfile)
        {
        }
    }
}