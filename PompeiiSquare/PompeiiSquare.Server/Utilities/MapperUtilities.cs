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
            Mapper.CreateMap<OpenHoursBindingModel, OpenHours>();

            Mapper.CreateMap<VenueGroupBindingModel, VenueGroup>()
                .ForMember(v => v.Venues, opt => opt.Ignore());

            Mapper.CreateMap<VenueCreateBindingModel, Venue>()
                .ForMember(v => v.OpenHours, opt => opt.MapFrom(v => v.OpenHours))
                .ForMember(v => v.Tags, opt => opt.Ignore())
                .ForMember(v => v.Groups, opt => opt.Ignore());

            Mapper.CreateMap<Venue, VenueEditBindingModel>()
                .ForMember(v => v.OpenHours, opt => opt.Ignore())
                .ForMember(v => v.Tags, opt => opt.Ignore())
                .ForMember(v => v.Groups, opt => opt.Ignore());

            Mapper.CreateMap<VenueEditBindingModel, Venue>()
                .ForMember(v => v.OpenHours, opt => opt.Ignore())
                .ForMember(v => v.Tags, opt => opt.Ignore())
                .ForMember(v => v.Groups, opt => opt.Ignore());

            Mapper.CreateMap<Venue, VenueDeleteBindingModel>()
               .ForMember(v => v.OpenHours, opt => opt.Ignore())
               .ForMember(v => v.Tags, opt => opt.Ignore())
               .ForMember(v => v.Groups, opt => opt.Ignore()); // TODO: Get all info
        }
    }
}