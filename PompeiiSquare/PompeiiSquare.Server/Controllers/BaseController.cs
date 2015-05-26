namespace PompeiiSquare.Server.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Routing;
    using System.Web.Mvc;

    using PompeiiSquare.Models;
    using PompeiiSquare.Data.UnitOfWork;

    public abstract class BaseController : Controller
    {
        private IPompeiiSquareData data;
        private User userProfile;

        protected BaseController(IPompeiiSquareData data)
        {
            this.Data = data;
        }

        protected BaseController(IPompeiiSquareData data, User userProfile)
            :this(data)
        {
            this.UserProfile = userProfile;
        }

        protected IPompeiiSquareData Data { get; private set; }

        protected User UserProfile { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var username = requestContext.HttpContext.User.Identity.Name;
                var user = this.Data.Users.All().FirstOrDefault(u => u.UserName == username);
                this.UserProfile = user;
            }

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}