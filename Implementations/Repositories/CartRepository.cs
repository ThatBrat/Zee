using Microsoft.EntityFrameworkCore;
using Zee.Interface.Repositories;

namespace Zee.Implementation.Repositories
{
    public class CartRepository : GenericRepository<Cart> , ICartRepository 
    {
        public CartRepository(ZeeDbContext Context) : base(Context)
        {
            _Context = Context;
        }

        public async Task<Cart> GetCart(int customerId)
        {
            var cart = await _Context.Carts.Include(x => x.Customer).Include(x => x.Items).SingleOrDefaultAsync(c => c.Customer.Id == customerId);
            return cart;
        }
    
    }
} 