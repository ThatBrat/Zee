using Zee.DTOs;
using Zee.DTOs.RequestModels;
using Zee.DTOs.ResponseModels;

namespace Zee.Interface.Services
{
    public interface ICartService
    {
        Task<BaseResponse> AddToCart(CreateCartItemRequestModel model, int customerId, int productId);
        Task<CartResponseModel> GetAllItems( int customerId);
    }
}