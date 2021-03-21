using GFTRestaurant.App.Dto;

namespace GFTRestaurant.App.Interfaces
{
    public interface IAppServiceOrder : IAppServiceBase<OrderDtoResponse>
    {
        OrderDtoResponse CreateAnOrder(string orderInput);
    }
}
