using AutoMapper;

namespace Kedust.Services.Profiles
{
    public class MenuProfiles: Profile
    {
        public MenuProfiles()
        {
            CreateMap<Data.Domain.Choice, DTO.Choice>().ReverseMap();
            CreateMap<Data.Domain.Menu, DTO.Menu>()
                .ForMember(x => x.Choices, map => map.MapFrom(m =>m.Choices))
                .ReverseMap();
            CreateMap<Data.Domain.Table, DTO.Table>().ReverseMap();
        }
    }
}