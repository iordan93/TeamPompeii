using PompeiiSquare.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PompeiiSquare.Server.Areas.UserAdministrator.Controllers
{
    public class UsersController : BaseUserAdministratorController
    {
        public UsersController(IPompeiiSquareData data)
            : base(data)
        {
        }

        // GET: UserAdministrator/Users
        public ActionResult Index()
        {
            var users = this.Data.Users.All();
            return View(users);
        }
    }
}