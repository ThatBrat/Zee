namespace Zee.Interface.Repositories
{
    public interface ICartItemRepository : IGenericRepository<CartItem>
    {
        Task<CartItem> GetCartItemAsync(int id);
        Task<IList<CartItem>> GetCartItemsAsync(int cartId);
    }
}