using GFTRestaurant.Domain.Entities;
using GFTRestaurant.Domain.Interfaces;

namespace GFTRestaurant.Infrastructure.Data.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly DatabaseContext _databaseContext;

        public OrderRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
            this._databaseContext = databaseContext;
        }
    }
}
