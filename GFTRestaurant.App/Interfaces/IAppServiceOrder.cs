using GFTRestaurant.App.Dto;

namespace GFTRestaurant.App.Interfaces
{
    public interface IAppServiceOrder : IAppServiceBase<OrderDto>
    {
        OrderDto CreateAnOrder(string orderInput);
    }
}
