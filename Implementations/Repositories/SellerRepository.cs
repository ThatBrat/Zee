using Microsoft.EntityFrameworkCore;
using Zee.DTOs.ResponseModels;
using Zee.Interface.Repositories;

namespace Zee.Implementation.Repositories
{
    public class SellerRepository : GenericRepository<Seller>, ISellerRepository
    {

        public SellerRepository(ZeeDbContext Context) : base(Context)
        {
            _Context = Context;
        }

        
        public async Task<Seller> GetSeller(int id)
        {
            var Seller = await _Context.Sellers.Include(x => x.Address).Include(x => x.User).Include(x => x.SellerDispatches).ThenInclude(x => x.Dispatch).SingleOrDefaultAsync(c => c.UserId == id);
            return Seller;
        }

        public async Task<IList<Seller>> GetSellers()
        {
            var sellers = await _Context.Sellers.Include(x => x.Address).Include(a => a.User).Include(x => x.SellerDispatches).ThenInclude(x => x.Dispatch).ToListAsync();
            return sellers;
        }

        
    }
}
