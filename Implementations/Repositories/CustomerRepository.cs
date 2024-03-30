using Microsoft.EntityFrameworkCore;
using Zee.DTOs.ResponseModels;
using Zee.Interface.Repositories;

namespace Zee.Implementation.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {

        public CustomerRepository(ZeeDbContext Context): base(Context)
        {
            _Context = Context;
        }

        
        public async Task<BaseResponse> ExistsByEmailAsync(string Email, string passWord)
        {
            var customer = await _Context.Customers.FirstOrDefaultAsync(c => c.User.Email == Email && c.User.Password == passWord);
            if (customer == null)
            {
                return new BaseResponse()
                {
                    Message = "Customer Not Found",
                    Success = false,
                };
            }
            return new BaseResponse()
            {
                Message = "Customer Found",
                Success = true,
            };
        }
        
        public async Task<Customer> GetCustomer(int id)
        {
            var customer = await _Context.Customers.Include(x => x.User).Include(x => x.Cart).SingleOrDefaultAsync(c => c.UserId == id);
            return customer;
        }
    }
}

