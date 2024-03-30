using Microsoft.EntityFrameworkCore;
using Zee.DTOs.ResponseModels;
using Zee.Interface.Repositories;

namespace Zee.Implementation.Repositories
{
    public class DispatchRepository : GenericRepository<Dispatch>, IDispatchRepository
    {

        public DispatchRepository(ZeeDbContext Context) : base(Context)
        {
            _Context = Context;
        }

         public async Task<Dispatch> GetDispatch(int id)
        {
            var dispatch = await _Context.Dispatches.Include(x => x.SellerDispatches).Include(x => x.User).SingleOrDefaultAsync(c => c.UserId == id);
            return dispatch;
        }

         public async Task<Dispatch> GetDispatch(string email)
        {
            var dispatch = await _Context.Dispatches.Include(x => x.SellerDispatches).Include(x => x.User).SingleOrDefaultAsync(c => c.User.Email == email);
            return dispatch;
            
        }

        public async Task<List<Dispatch>> GetDispatches(int sellerId)
        {
            var dispatches = await _Context.Dispatches.Include(x => x.SellerDispatches.Where(x => x.SellerId == sellerId)).Include(a => a.User).ToListAsync();
            return dispatches;
        }
       
    }
}
