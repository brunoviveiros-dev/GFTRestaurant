using GFTRestaurant.Domain.Entitys;

namespace GFTRestaurant.Domain.Interfaces.Services
{
    public interface IServiceOrder : IBaseRepository<Order>
    {
        string PlaceAnOrder(string orderInput);
    }
}
