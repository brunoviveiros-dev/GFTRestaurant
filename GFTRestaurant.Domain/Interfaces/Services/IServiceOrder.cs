using GFTRestaurant.Domain.Entities;

namespace GFTRestaurant.Domain.Interfaces.Services
{
    public interface IServiceOrder : IServiceBase<Order>
    {
        Order CreateAnOrder(string orderInput);
    }
}
