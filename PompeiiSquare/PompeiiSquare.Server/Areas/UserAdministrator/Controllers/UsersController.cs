using AutoMapper;
using PompeiiSquare.Data.UnitOfWork;
using PompeiiSquare.Server.Areas.UserAdministrator.Models;
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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = this.Data.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            var userModel = Mapper.Map<UserBindingModel>(user);
            return View(user);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(string id, UserBindingModel model)
        {
            var user = this.Data.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return RedirectToAction("Index");
        }
    }
}