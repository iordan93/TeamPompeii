using System.Web.Mvc;

namespace PompeiiSquare.Server.Areas.VenueAdministrator
{
    public class VenueAdministratorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "VenueAdministrator";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "VenueAdministrator_default",
                "VenueAdministrator/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}