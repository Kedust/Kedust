using System;
using AutoMapper;

namespace Kedust.Services.Profiles
{
    public class MenuProfiles: Profile
    {
        public MenuProfiles()
        {
            CreateMap<Data.Domain.Choice, Menu.Choice>().ReverseMap();
            CreateMap<Data.Domain.Menu, Menu.Menu>()
                .ForMember(x => x.Choices, map => map.MapFrom(m =>m.Choices))
                .ReverseMap();
            
            CreateMap<Data.Domain.Table, Menu.Table>()
                .ForMember(x => x.Menu, map => map.MapFrom(t => t.Menu))
                .ReverseMap();
        }
    }
}