using AutoMapper;
using GFTRestaurant.App.Dto;
using GFTRestaurant.Domain.Entities;

namespace GFTRestaurant.App.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            OrderDtoToOrderMap();
            OrderToOrderDtoMap();
        }

        private void OrderDtoToOrderMap()
        {
            CreateMap<OrderDto, Order>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Detail, opt => opt.MapFrom(x => x.Detail));
        }

        private void OrderToOrderDtoMap()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.Detail, opt => opt.MapFrom(x => x.Detail));
        }
    }
}
