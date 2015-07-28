using PompeiiSquare.Data;
using PompeiiSquare.Data.Migrations;
using PompeiiSquare.Server.App_Start;
using PompeiiSquare.Server.Utilities;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PompeiiSquare.Server
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<PompeiiSquareDbContext>(new MigrateDatabaseToLatestVersion<PompeiiSquareDbContext, Configuration>());
            // This is a test comment
            MapperUtilities.CreateAllMaps();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ViewEnginesConfig.RegisterViewEngines(ViewEngines.Engines);
            ModelBindersConfig.RegisterModelBinders();
        }
    }
}
