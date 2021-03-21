using AutoMapper;
using GFTRestaurant.App.Dto;
using GFTRestaurant.Domain.Entities;

namespace GFTRestaurant.App.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            OrderDtoResponseToOrderMap();
            OrderToOrderDtoResponseMap();
        }

        private void OrderDtoResponseToOrderMap()
        {
            CreateMap<OrderDtoResponse, Order>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Detail, opt => opt.MapFrom(x => x.Detail));
        }

        private void OrderToOrderDtoResponseMap()
        {
            CreateMap<Order, OrderDtoResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Detail, opt => opt.MapFrom(x => x.Detail));
        }
    }
}
