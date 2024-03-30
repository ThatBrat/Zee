using Zee.DTOs.RequestModels;
using Zee.DTOs.ResponseModels;

namespace Zee.Interface.Services
{
    public interface IPaymentService
    {
        Task<PaymentsResponseModel> MakePayment(int orderId, decimal amount);
        Task<PaymentsResponseModel> GetPaymentById(int paymentId);
    }
}