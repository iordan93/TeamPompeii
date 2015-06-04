using PompeiiSquare.Data.UnitOfWork;
using PompeiiSquare.Models;
using PompeiiSquare.Server.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PompeiiSquare.Server.Areas.UserAdministrator.Controllers
{
    public class BaseUserAdministratorController : BaseController
    {
        protected BaseUserAdministratorController(IPompeiiSquareData data)
            : base(data)
        {
        }

        protected BaseUserAdministratorController(IPompeiiSquareData data, User userProfile)
            : base(data, userProfile)
        {
        }
    }
}