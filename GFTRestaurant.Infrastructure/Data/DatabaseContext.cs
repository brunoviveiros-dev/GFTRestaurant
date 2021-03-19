using GFTRestaurant.Domain.Entitys;
using Microsoft.EntityFrameworkCore;

namespace GFTRestaurant.Infrastructure.Data
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}
