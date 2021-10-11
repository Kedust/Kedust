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
            
            CreateMap<Data.Domain.OrderItem, DTO.OrderItemForPrinting>()
                .ForMember(dest => dest.Amount, map => map.MapFrom(src => src.Amount))
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Choice.Name))
                .ForMember(dest => dest.Price, map => map.MapFrom(src => src.Choice.Price));
            CreateMap<Data.Domain.Order, DTO.OrderForPrinting>()
                .ForMember(dest => dest.Table, map => map.MapFrom(src => src.Table))
                .ForMember(dest => dest.OrderItems, map => map.MapFrom(src => src.OrderItems));

            CreateMap<DTO.OrderItemForSaving, Data.Domain.OrderItem>()
                .ForMember(dest => dest.Amount, map => map.MapFrom(src => src.Amount))
                .ForMember(dest => dest.ChoiceId, map => map.MapFrom(src => src.ChoiceId));
            CreateMap<DTO.OrderForSaving, Data.Domain.Order>()
                .ForMember(dest => dest.TableId, map => map.MapFrom(src => src.TableId))
                .ForMember(dest => dest.OrderItems, map => map.MapFrom(src => src.OrderItems));
        }
    }
}