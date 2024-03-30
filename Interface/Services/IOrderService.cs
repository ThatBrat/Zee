using Zee.DTOs;
using Zee.DTOs.RequestModels;
using Zee.DTOs.ResponseModels;

namespace Zee.Interface.Services
{
    public interface IOrderService
    {
        Task<BaseResponse> CreateOrder(CreateOrderRequestModel model);
        Task<OrderResponseModel> GetByRefNo(int RefNo);
        Task<OrdersResponseModel> GetByCustomerId(int id);            
    }
}