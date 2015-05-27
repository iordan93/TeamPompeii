using PompeiiSquare.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PompeiiSquare.Server.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IPompeiiSquareData data)
            :base(data)
        {

        }

        public ActionResult Index()
        {
            return View();
        }
    }
}