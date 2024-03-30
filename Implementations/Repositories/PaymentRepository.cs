using Microsoft.EntityFrameworkCore;
using Zee.Interface.Repositories;

namespace Zee.Implementation.Repositories
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(ZeeDbContext Context) : base(Context)
        {
            _Context = Context;
        }

       public async Task<Payment> GetPayment(int id)
        {
            var payment = await _Context.Payments.Include(x => x.Customer).Include(x => x.Admin).Include(x => x.Order).Include(x => x.Seller).SingleOrDefaultAsync(c => c.Id == id);
            return payment;}

        public async Task<List<Payment>> GetAllPayments()
        {
            var payments =  await _Context.Payments.Include(p => p.Seller).Include(p => p.Customer).Include(p => p.Order).Include(p => p.Admin).ToListAsync();
            return payments;
        }       
    }
}