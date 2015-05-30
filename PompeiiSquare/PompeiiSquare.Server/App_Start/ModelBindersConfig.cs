using PompeiiSquare.Server.Utilities;
using System.Data.Entity.Spatial;
using System.Web.Mvc;
namespace PompeiiSquare.Server.App_Start
{
    public class ModelBindersConfig
    {
        public static void RegisterModelBinders() 
        {
            ModelBinders.Binders.Add(typeof(double), new DecimalModelBinder());
            ModelBinders.Binders.Add(typeof(double?), new DecimalModelBinder());
            ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());
            ModelBinders.Binders.Add(typeof(decimal?), new DecimalModelBinder());
            ModelBinders.Binders.Add(typeof(DbGeography), new DbGeographyModelBinder());
        }
    }
}