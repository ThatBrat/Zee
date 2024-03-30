using System.Linq.Expressions;
using Zee.DTOs;

namespace Zee.Interface.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        //  Task<IEnumerable<User>> GetAllUser();
        // Task<IEnumerable<User>> GetAllUser(Expression<Func<User, bool>> expression, bool AsNoTracking = true, CancellationToken cancellationToken = default);
        // Task<IEnumerable<User>> GetAllUsers();
        // Task<User> GetUser(string id);
        // Task<User> GetUser(Expression<Func<User, bool>> expression, bool AsNoTracking = true, CancellationToken cancellationToken = default);
        // Task<User> GetUserAsync(string email);
        // Task<User> GetUserByEmailAsync(string email);
        // Task<string> GetUserNameById(string id);
        // Task<List<UserDto>> LoadUsersAsync(string filter, int page, int limit);
    }
}