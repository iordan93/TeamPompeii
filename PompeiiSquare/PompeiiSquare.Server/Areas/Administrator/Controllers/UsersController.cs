using PompeiiSquare.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PompeiiSquare.Server.Areas.Administrator.Controllers
{
    public class UsersController : BaseAdministratorController
    {
         public UsersController(IPompeiiSquareData data)
            : base(data)
        {
        }

        // GET: Administrator/Users
        public ActionResult Index()
        {
            // TODO: return UserShowModels
            var usersFromDb = Data.Users.All().ToList();
            return this.View(usersFromDb);
        }
    }
}