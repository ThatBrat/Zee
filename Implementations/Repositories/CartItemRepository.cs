using Microsoft.EntityFrameworkCore;
using Zee.Interface.Repositories;

namespace Zee.Implementation.Repositories
{
    public class CartItemRepository : GenericRepository<CartItem> , ICartItemRepository 
    {
        public CartItemRepository(ZeeDbContext Context) : base(Context)
        {
            _Context = Context;
        }

        public async Task<CartItem> GetCartItemAsync(int id)
        {
            var CartItem = await _Context.CartItems.Include(x => x.Cart).Include(x => x.CartItemOrders).ThenInclude(x => x.Order).SingleOrDefaultAsync(c => c.Id == id);
            return CartItem;
        }

        public async Task<IList<CartItem>> GetCartItemsAsync(int cartId)
        {
            var cartItems = await _Context.CartItems.Where(a => a.CartId == cartId).Include(x => x.Cart).Include(a => a.CartItemOrders).ThenInclude(a => a.Order).ToListAsync();
            return cartItems;
        }
    
    }
} 