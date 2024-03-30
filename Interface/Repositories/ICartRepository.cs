namespace Zee.Interface.Repositories
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        Task<Cart> GetCart(int customerId);
        
   
    }
}