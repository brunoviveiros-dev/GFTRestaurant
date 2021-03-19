using GFTRestaurant.Domain.Entitys;

namespace GFTRestaurant.Domain.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        string PlaceAnOrder(string orderInput);
    }
}
