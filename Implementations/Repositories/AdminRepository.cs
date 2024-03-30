using Microsoft.EntityFrameworkCore;
using Zee.DTOs.ResponseModels;
using Zee.Interface.Repositories;

namespace Zee.Implementation.Repositories
{
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {

        public AdminRepository(ZeeDbContext Context) : base(Context)
        {
            _Context = Context;
        } 
        public async Task<Admin> GetAdmin(int id)
        {
            var admin = await _Context.Admins.Include(x => x.User).SingleOrDefaultAsync(c => c.UserId == id);
            return admin;
        }
    }
}
