namespace Zee.Interface.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<Order> GetOrder(int id);
        Task<IList<Order>> GetOrders(int CustomerId);
    }
}