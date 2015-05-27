using AutoMapper;
using PompeiiSquare.Models;
using PompeiiSquare.Server.Areas.VenueAdministrator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PompeiiSquare.Server.Utilities
{
    public class MapperUtilities
    {
        public static void CreateAllMaps() 
        {
            Mapper.CreateMap<VenueCreateBindingModel, Venue>()
                .ForMember(v => v.Tags, opt => opt.Ignore());
        }
    }
}