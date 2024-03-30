using Microsoft.EntityFrameworkCore;
using Zee.Interface.Repositories;

namespace Zee.Implementation.Repositories
{
    public class OrderRepository : GenericRepository<Order> , IOrderRepository 
    {
        public OrderRepository(ZeeDbContext Context) : base(Context)
        {
            _Context = Context;
        }

         public async Task<Order> GetOrder(int id)
        {
            var order = await _Context.Orders.Include(x => x.Customer).Include(x => x.Payment).Include(x => x.Seller).Include(x => x.DeliveryAddress).Include(x => x.CartItemOrders).ThenInclude(x => x.Item).SingleOrDefaultAsync(c => c.Id == id);
            return order;
        }

        public async Task<IList<Order>> GetOrders(int customerId)
        {
            var orders = await _Context.Orders.Where(c => c.CustomerId == customerId).Include(x => x.Customer).Include(x => x.Payment).Include(x => x.Seller).Include(x => x.DeliveryAddress).Include(x => x.CartItemOrders).ThenInclude(x => x.Item).ToListAsync();
            return orders;
        }
    }
} 