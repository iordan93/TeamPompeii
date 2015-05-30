namespace PompeiiSquare.Server.App_Start
{
    using System.Web.Mvc;

    public class ViewEnginesConfig
    {
        internal static void RegisterViewEngines(ViewEngineCollection viewEngineCollection)
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}