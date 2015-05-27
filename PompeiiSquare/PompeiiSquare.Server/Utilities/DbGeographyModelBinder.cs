using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PompeiiSquare.Server.Utilities
{
    public class DbGeographyModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            string[] latLongStr = valueProviderResult.AttemptedValue.Split(',');
            string point = string.Format("POINT ({0} {1})", latLongStr[1], latLongStr[0]);
            //4326 format puts LONGITUDE first then LATITUDE
            DbGeography result = valueProviderResult == null ? null : DbGeography.FromText(point, 4326);
            return result;
        }
    }
}