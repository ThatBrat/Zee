using Microsoft.EntityFrameworkCore;
using Zee.Interface.Repositories;

namespace Zee.Implementation.Repositories
{
    public class AddressRepository : GenericRepository<Address> , IAddressRepository 
    {
        public AddressRepository(ZeeDbContext Context) : base(Context)
        {
            _Context = Context;
        }
    
    }
} 