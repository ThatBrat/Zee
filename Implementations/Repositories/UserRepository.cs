using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Zee.DTOs;
using Zee.Interface.Repositories;

namespace Zee.Implementation.Repositories
{

    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ZeeDbContext _dbcontext;

        public UserRepository(ZeeDbContext context) : base(context)
        {
            _dbcontext = context;
        }

        // public async Task<User> GetUserAsync(string email)
        // {
        //     return await _dbcontext.Users.Include(u => u.Customer).Include(u => u.Seller).Include(u => u.Admin).Include(u => u.Dispatch).SingleOrDefaultAsync(u => u.Email == email);
        // }
        // public async Task<string> GetUserNameById(string id)
        // {
        //     var user = await _dbcontext.Users.AsNoTracking().Where(u => u.Id == id).Select(x => x.UserName).SingleOrDefaultAsync();
        //     return user;
        // }

        // public async Task<User> GetUser(string id)
        // {
        //     return await _dbcontext.Users.Include(u => u.Customer).Include(u => u.Seller).Include(u => u.Admin).Include(u => u.Dispatch).SingleOrDefaultAsync(u => u.Id == id);
        // }

        // public async Task<List<UserDto>> LoadUsersAsync(string filter, int page, int limit)
        // {
        //     var query = _dbcontext.Users.Include(u => u.Customer).Include(u => u.Seller).Include(u => u.Admin).Include(u => u.Dispatch).Where(c => filter == null || c.FirstName.Contains(filter) || c.LastName.Contains(filter) || c.Email.Contains(filter)).OrderBy(c => c.FirstName);



        //     return await query.Select(c => new UserDto
        //     {
        //         Id = Guid.Parse(c.Id),
        //         FirstName = c.FirstName,
        //         LastName = c.LastName,
        //         Email = c.Email
        //     })
        //               .AsNoTracking()
        //               .ToListAsync();

        // }

        // public async Task<IEnumerable<User>> GetAllUser()
        // {
        //     return await _dbcontext.Users.ToListAsync();
        // }


        // public async Task<User?> GetUserByEmailAsync(string email)
        // {
        //     return await _dbcontext.Users.SingleOrDefaultAsync(u => u.Email == email);
        // }


        // public async Task<IEnumerable<User>> GetAllUser(Expression<Func<User, bool>> expression, bool AsNoTracking = true, CancellationToken cancellationToken = default)
        // {
        //     IQueryable<User> query = _dbcontext.Users;
        //     if (AsNoTracking) query = query.AsNoTracking();
        //     if (expression != null) query = query
        //             .Where(expression);
        //     return await query.ToListAsync(cancellationToken);
        // }

        // public async Task<IEnumerable<User>> GetAllUsers()
        // {
        //     IQueryable<User> query = _dbcontext.Users;
        //     if (query != null) query = query;
        //     return await query;
        // }
        // public async Task<User> GetUser(Expression<Func<User, bool>> expression, bool AsNoTracking = true, CancellationToken cancellationToken = default)
        // {
        //     IQueryable<User> query = _dbcontext.Users;
        //     if (AsNoTracking) query = query.AsNoTracking();
        //     return await query
        //             .Where(expression)
        //             .SingleOrDefaultAsync(cancellationToken);
        // }

    }
}